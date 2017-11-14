using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Linq.Expressions;

using Microsoft.EntityFrameworkCore;

using DocsVision.Platform.DataModel.Entities;

namespace DocsVision.Platform.DataModel
{
	internal class MetadataProvider : IMetadataProvider
	{
		private readonly DbContextScope<MetadataContext> _contextScope;
		private readonly ConcurrentDictionary<Guid, Dictionary<string, Guid>> _sections;

		private bool _metadataLoaded;

		public MetadataProvider(DbContextScope<MetadataContext> contextScope)
		{
			_contextScope = contextScope ?? throw new ArgumentNullException(nameof(contextScope));
			_sections = new ConcurrentDictionary<Guid, Dictionary<string, Guid>>();
		}

		public Guid GetSectionID(Guid cardTypeID, string sectionAlias)
		{
			var cardSections = _sections.GetOrAdd(cardTypeID, GetCardSections);

			Guid sectionID = Guid.Empty;
			cardSections.TryGetValue(sectionAlias, out sectionID);
			return sectionID;
		}

		private Dictionary<string, Guid> GetCardSections(Guid cardTypeID)
		{
			var context = _contextScope.GetContext();

			var query = context.Set<CardSection>()
				.Where(x => x.CardTypeID == cardTypeID)
				.OrderBy(x => x.Alias)
				.Select(x => new
				{
					SectionID = x.Id,
					SectionAlias = x.Alias
				});

			Dictionary<string, Guid> cardSections = new Dictionary<string, Guid>();

			var sections = query.ToList();
			foreach (var section in sections)
			{
				cardSections[section.SectionAlias] = section.SectionID;
			}

			return cardSections;
		}
	}
}
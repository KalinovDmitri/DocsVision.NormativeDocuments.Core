using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using Microsoft.EntityFrameworkCore;

using DocsVision.Platform.DataModel.Entities;

namespace DocsVision.Platform.DataModel
{
	internal class MetadataProvider : IMetadataProvider
	{
		private readonly MetadataContext _metadataContext;
		private readonly Dictionary<Guid, Dictionary<string, Guid>> _sections = new Dictionary<Guid, Dictionary<string, Guid>>();

		private bool _metadataLoaded;

		public MetadataProvider(MetadataContext metadataContext)
		{
			_metadataContext = metadataContext ?? throw new ArgumentNullException(nameof(metadataContext));
		}

		public Guid GetSectionID(Guid cardTypeID, string sectionAlias)
		{
			PreloadMetadataIfNeeded();

			Guid sectionID = Guid.Empty;

			Dictionary<string, Guid> cardSections = null;
			if (_sections.TryGetValue(cardTypeID, out cardSections))
			{
				cardSections.TryGetValue(sectionAlias, out sectionID);
			}

			return sectionID;
		}
		
		private void PreloadMetadataIfNeeded()
		{
			if (_metadataLoaded) return;

			var query = _metadataContext.Set<CardSection>()
				.Where(x => x.IsDynamic || x.Extended)
				.OrderBy(x => x.CardTypeID)
				.ThenBy(x => x.Alias)
				.Select(x => new
				{
					CardTypeID = x.CardTypeID,
					SectionID = x.Id,
					SectionAlias = x.Alias
				});

			Dictionary<string, Guid> cardSections = null;

			var sections = query.ToList();
			foreach (var sectionInfo in sections)
			{
				if (_sections.TryGetValue(sectionInfo.CardTypeID, out cardSections))
				{
					cardSections[sectionInfo.SectionAlias] = sectionInfo.SectionID;
					continue;
				}
				
				_sections[sectionInfo.CardTypeID] = new Dictionary<string, Guid>(StringComparer.Ordinal)
				{
					[sectionInfo.SectionAlias] = sectionInfo.SectionID
				};
			}

			_metadataLoaded = true;
		}
	}
}
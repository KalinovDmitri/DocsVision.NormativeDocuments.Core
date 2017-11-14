using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

using DocsVision.Platform.DataModel.Mapping;

namespace DocsVision.Platform.DataModel
{
	public class DocsVisionSchema : IEntityMapperVisitor
	{
		private readonly List<IEntityMapper> _registeredMappers = new List<IEntityMapper>(30);
		private readonly Dictionary<Type, Guid> _cardDiscriminators = new Dictionary<Type, Guid>();

		private bool _isFrozen = false;

		public DocsVisionSchema()
		{
			_registeredMappers.Add(new BaseCardMapper(GetDiscriminators));

			RegisterMetadataMappers();
			RegisterCardMappers();
			RegisterDictionaryMappers();
		}

		public void RegisterMapper(IEntityMapper entityMapper)
		{
			if (_isFrozen)
			{
				throw new InvalidOperationException("DocsVision database schema is already frozen.");
			}
			if (entityMapper == null)
			{
				throw new ArgumentNullException(nameof(entityMapper), "Entity mapper cannot be null.");
			}

			entityMapper.Accept(this);

			_registeredMappers.Add(entityMapper);
		}

		public void BuildModel(IMetadataProvider metadataProvider, ModelBuilder modelBuilder)
		{
			foreach (IEntityMapper entityMapper in _registeredMappers)
			{
				if (entityMapper.ShouldResolveMetadata)
				{
					entityMapper.ResolveMetadata(metadataProvider);
				}

				entityMapper.Map(modelBuilder);
			}

			_isFrozen = true;
		}

		private void RegisterMetadataMappers()
		{
			RegisterMapper(new CardLibraryMapper());
			RegisterMapper(new CardTypeMapper());
			RegisterMapper(new CardSectionMapper());
		}

		private void RegisterCardMappers()
		{
			RegisterMapper(new DocumentMapper());
			RegisterMapper(new DocumentMainInfoMapper());
			RegisterMapper(new DocumentNumberMapper());
			RegisterMapper(new DocumentSystemInfoMapper());
		}

		private void RegisterDictionaryMappers()
		{

		}

		private IReadOnlyDictionary<Type, Guid> GetDiscriminators() => _cardDiscriminators;

		void IEntityMapperVisitor.VisitCard(ICardMapper cardMapper)
		{
			_cardDiscriminators[cardMapper.CardType] = cardMapper.CardTypeID;
		}
	}
}
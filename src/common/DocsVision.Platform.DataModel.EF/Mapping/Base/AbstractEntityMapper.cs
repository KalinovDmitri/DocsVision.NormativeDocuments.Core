using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using DocsVision.Platform.DataModel.Entities;

namespace DocsVision.Platform.DataModel.Mapping
{
	public abstract class AbstractEntityMapper<TEntity> : IEntityMapper where TEntity : AbstractEntity
	{
		public virtual bool ShouldResolveMetadata => false;

		protected internal AbstractEntityMapper() { }

		public void Map(ModelBuilder modelBuilder)
		{
			var entityBuilder = modelBuilder.Entity<TEntity>();

			MapEntity(entityBuilder);
		}

		public virtual void ResolveMetadata(IMetadataProvider metadataProvider) { }

		public virtual void Accept(IEntityMapperVisitor visitor) { }

		protected abstract void MapEntity(EntityTypeBuilder<TEntity> entityBuilder);
	}
}
using System;

using Microsoft.EntityFrameworkCore;

namespace DocsVision.Platform.DataModel
{
	public interface IEntityMapper
	{
		bool ShouldResolveMetadata { get; }

		void Map(ModelBuilder modelBuilder);

		void ResolveMetadata(IMetadataProvider metadataProvider);

		void Accept(IEntityMapperVisitor visitor);
	}
}
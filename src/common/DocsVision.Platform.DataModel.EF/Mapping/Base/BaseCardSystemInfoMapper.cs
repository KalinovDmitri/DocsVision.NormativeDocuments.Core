using System;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

using DocsVision.Platform.DataModel.Entities;

namespace DocsVision.Platform.DataModel.Mapping
{
	public abstract class BaseCardSystemInfoMapper<TSystemInfo> : BaseCardSectionRowMapper<TSystemInfo> where TSystemInfo : BaseCardSystemInfo
	{
		protected internal BaseCardSystemInfoMapper(Guid sectionID) : base(sectionID) { }

		protected override void MapEntity(EntityTypeBuilder<TSystemInfo> entityBuilder)
		{
			base.MapEntity(entityBuilder);

			entityBuilder.Property(x => x.Kind);
			entityBuilder.Property(x => x.State);
		}
	}
}
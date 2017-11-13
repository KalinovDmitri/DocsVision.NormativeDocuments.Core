using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using DocsVision.Platform.DataModel.Entities;

namespace DocsVision.Platform.DataModel.Mapping
{
	public class BaseCardSystemInfoMapper : DynamicSectionRowMapper<BaseCardSystemInfo>
	{
		public BaseCardSystemInfoMapper(Guid cardTypeID) : base(cardTypeID, "System") { }

		protected override void MapEntity(EntityTypeBuilder<BaseCardSystemInfo> entityBuilder)
		{
			base.MapEntity(entityBuilder);

			entityBuilder.Property(x => x.Kind);
			entityBuilder.Property(x => x.State);
		}
	}
}
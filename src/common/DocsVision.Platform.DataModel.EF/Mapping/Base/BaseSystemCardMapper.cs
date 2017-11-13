using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using DocsVision.Platform.DataModel.Entities;

namespace DocsVision.Platform.DataModel.Mapping
{
	public abstract class BaseSystemCardMapper<TSystemCard> : BaseCardMapper<TSystemCard> where TSystemCard : BaseSystemCard
	{
		protected internal BaseSystemCardMapper(Guid typeID) : base(typeID) { }

		protected override void MapEntity(EntityTypeBuilder<TSystemCard> entityBuilder)
		{
			base.MapEntity(entityBuilder);

			entityBuilder.Ignore(x => x.SystemInfo);
		}
	}
}
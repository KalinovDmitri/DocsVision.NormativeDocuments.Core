using System;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

using DocsVision.Platform.DataModel.Entities;

namespace DocsVision.Platform.DataModel.Mapping
{
	public abstract class BaseCardNumberMapper<TCardNumber> : BaseCardSectionRowMapper<TCardNumber> where TCardNumber : BaseCardNumber
	{
		protected internal BaseCardNumberMapper(Guid sectionID) : base(sectionID) { }

		protected override void MapEntity(EntityTypeBuilder<TCardNumber> entityBuilder)
		{
			base.MapEntity(entityBuilder);

			entityBuilder.Property(x => x.NumericPart);
			entityBuilder.Property(x => x.Number);
		}
	}
}
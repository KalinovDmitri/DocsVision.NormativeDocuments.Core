using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using DocsVision.Platform.DataModel.Entities;

namespace DocsVision.Platform.DataModel.Mapping
{
	public sealed class CardSectionMapper : AbstractEntityMapper<CardSection>
	{
		public CardSectionMapper() : base() { }

		protected override void MapEntity(EntityTypeBuilder<CardSection> entityBuilder)
		{
			entityBuilder.ToTable("dvsys_sectiondefs");
		}
	}
}
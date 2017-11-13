using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using DocsVision.Platform.DataModel.Entities;

namespace DocsVision.Platform.DataModel.Mapping
{
	public sealed class CardTypeMapper : AbstractEntityMapper<CardType>
	{
		public CardTypeMapper() : base() { }

		protected override void MapEntity(EntityTypeBuilder<CardType> entityBuilder)
		{
			entityBuilder.ToTable("dvsys_carddefs");

			entityBuilder.Property(x => x.Id).HasColumnName("CardTypeID");
			entityBuilder.Property(x => x.Alias);
			entityBuilder.Property(x => x.LibraryID);
			entityBuilder.Property(x => x.ControlInfo);
			entityBuilder.Property(x => x.FetchMode);
			entityBuilder.Property(x => x.Options);
			entityBuilder.Property(x => x.SDID);

			entityBuilder.HasOne(x => x.Library).WithMany()
				.HasForeignKey(x => x.LibraryID)
				.HasPrincipalKey(x => x.Id);

			entityBuilder.HasMany(x => x.Sections).WithOne()
				.HasForeignKey(x => x.CardTypeID)
				.HasPrincipalKey(x => x.Id);
		}
	}
}
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
			entityBuilder.Property(x => x.Alias).HasMaxLength(64).IsUnicode(false);
			entityBuilder.Property(x => x.Version);
			entityBuilder.Property(x => x.SysVersion);
			entityBuilder.Property(x => x.LibraryID);
			entityBuilder.Property(x => x.ControlInfo).HasMaxLength(256).IsUnicode(false);
			entityBuilder.Property(x => x.FetchMode);
			entityBuilder.Property(x => x.Options);
			entityBuilder.Property(x => x.SDID);
			entityBuilder.Property(x => x.Timestamp).IsRowVersion();
			entityBuilder.Property(x => x.TypeName).HasMaxLength(2048).IsUnicode(false);

			entityBuilder.HasKey(x => x.Id).HasName("dvsys_carddefs_pk_cardtypeid");

			entityBuilder.HasOne(x => x.Security).WithMany()
				.HasForeignKey(x => x.SDID)
				.HasPrincipalKey(x => x.Id);

			entityBuilder.HasOne(x => x.Library).WithMany()
				.HasForeignKey(x => x.LibraryID)
				.HasPrincipalKey(x => x.Id);

			entityBuilder.HasMany(x => x.Sections).WithOne()
				.HasForeignKey(x => x.CardTypeID)
				.HasPrincipalKey(x => x.Id);
		}
	}
}
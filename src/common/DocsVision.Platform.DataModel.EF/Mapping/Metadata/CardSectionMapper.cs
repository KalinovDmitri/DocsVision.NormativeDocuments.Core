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

			entityBuilder.Property(x => x.Id).HasColumnName("SectionTypeID");
			entityBuilder.Property(x => x.Alias).HasMaxLength(64).IsUnicode(false);
			entityBuilder.Property(x => x.ParentSectionID);
			entityBuilder.Property(x => x.CardTypeID);
			entityBuilder.Property(x => x.SecurityType);
			entityBuilder.Property(x => x.UserDependent);
			entityBuilder.Property(x => x.Extended);
			entityBuilder.Property(x => x.NestLevel);
			entityBuilder.Property(x => x.Type);
			entityBuilder.Property(x => x.Flags);
			entityBuilder.Property(x => x.IsDynamic);
			entityBuilder.Property(x => x.New);

			entityBuilder.HasKey(x => x.Id).ForSqlServerIsClustered(false).HasName("dvsys_sectiondefs_pk_sectiontypeid");

			entityBuilder.HasOne(x => x.ParentType).WithMany()
				.HasForeignKey(x => x.CardTypeID)
				.HasPrincipalKey(x => x.Id);

			entityBuilder.HasOne(x => x.ParentSection).WithMany()
				.HasForeignKey(x => x.ParentSectionID)
				.HasPrincipalKey(x => x.Id);

			entityBuilder.HasMany(x => x.Sections).WithOne()
				.HasForeignKey(x => x.ParentSectionID)
				.HasPrincipalKey(x => x.Id);
		}
	}
}
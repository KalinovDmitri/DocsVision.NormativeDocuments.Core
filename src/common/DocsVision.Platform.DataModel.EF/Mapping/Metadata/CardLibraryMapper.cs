using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using DocsVision.Platform.DataModel.Entities;

namespace DocsVision.Platform.DataModel.Mapping
{
	public sealed class CardLibraryMapper : AbstractEntityMapper<CardLibrary>
	{
		public CardLibraryMapper() : base() { }

		protected override void MapEntity(EntityTypeBuilder<CardLibrary> entityBuilder)
		{
			entityBuilder.ToTable("dvsys_libraries");

			entityBuilder.Property(x => x.Id).HasColumnName("ID");
			entityBuilder.Property(x => x.Alias);
			entityBuilder.Property(x => x.Version);
			entityBuilder.Property(x => x.SysVersion);
			entityBuilder.Property(x => x.ControlInfo);
			entityBuilder.Property(x => x.MsiPackageName);
			entityBuilder.Property(x => x.MsiPatchCode);
			entityBuilder.Property(x => x.MsiPatchName);
			entityBuilder.Property(x => x.MsiProductCode);
			entityBuilder.Property(x => x.MsiTransformName);

			entityBuilder.HasKey(x => x.Id).HasName("dvsys_libraries_pk_id");

			entityBuilder.HasMany(x => x.Cards).WithOne()
				.HasForeignKey(x => x.LibraryID)
				.HasPrincipalKey(x => x.Id);
		}
	}
}
using System;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

using DocsVision.Platform.DataModel.CardDefs;
using DocsVision.Platform.DataModel.Entities;

namespace DocsVision.Platform.DataModel.Mapping
{
	public sealed class DocumentMainInfoMapper : BaseCardSectionRowMapper<DocumentMainInfo>
	{
		public DocumentMainInfoMapper() : base(CardDocument.MainInfo.ID) { }

		protected override void MapEntity(EntityTypeBuilder<DocumentMainInfo> entityBuilder)
		{
			base.MapEntity(entityBuilder);

			entityBuilder.Property(x => x.Name).HasMaxLength(480).IsUnicode();
			entityBuilder.Property(x => x.Author);
			entityBuilder.Property(x => x.VersioningType);
			entityBuilder.Property(x => x.CategoryList);
			entityBuilder.Property(x => x.RegDate);
			entityBuilder.Property(x => x.ExternalNumber).HasMaxLength(256).IsUnicode(false);
			entityBuilder.Property(x => x.Content).IsUnicode(false);
			entityBuilder.Property(x => x.ReferenceList);
			entityBuilder.Property(x => x.Tasks);
			entityBuilder.Property(x => x.SignatureList);
			entityBuilder.Property(x => x.ResponsDepartment);
			entityBuilder.Property(x => x.RegNumber);
			entityBuilder.Property(x => x.Registrar);
			entityBuilder.Property(x => x.SenderStaffEmployee);
			entityBuilder.Property(x => x.DeliveryDate);
			entityBuilder.Property(x => x.AcquaintanceGroup);
			entityBuilder.Property(x => x.SecurityId);
			entityBuilder.Property(x => x.RegistrationPlaceId);
			entityBuilder.Property(x => x.CaseId);
			entityBuilder.Property(x => x.DeliveryTypeId);
			entityBuilder.Property(x => x.NumberOfSheetsAppendix);
			entityBuilder.Property(x => x.NumberOfSheets);
			entityBuilder.Property(x => x.RegNumberProvisional);
			entityBuilder.Property(x => x.StatusId);
			entityBuilder.Property(x => x.TransferLog);
			entityBuilder.Property(x => x.ClerkId);
			entityBuilder.Property(x => x.WorkGroup);
			entityBuilder.Property(x => x.WasSent);
			entityBuilder.Property(x => x.ItemID);

			entityBuilder.HasOne(x => x.DocumentAuthor).WithMany()
				.HasForeignKey(x => x.Author)
				.HasPrincipalKey(x => x.Id);

			entityBuilder.HasOne(x => x.RegistrationNumber).WithOne()
				.HasForeignKey<DocumentMainInfo>(x => x.RegNumber)
				.HasPrincipalKey<DocumentNumber>(x => x.Id);
		}
	}
}
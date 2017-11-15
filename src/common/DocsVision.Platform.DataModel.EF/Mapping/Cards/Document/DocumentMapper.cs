using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using DocsVision.Platform.DataModel.CardDefs;
using DocsVision.Platform.DataModel.Entities;

namespace DocsVision.Platform.DataModel.Mapping
{
	public abstract class DocumentMapper<TDocument> : BaseCardMapper<TDocument> where TDocument : Document
	{
		protected internal DocumentMapper(Guid typeID) : base(typeID) { }

		protected override void MapEntity(EntityTypeBuilder<TDocument> entityBuilder)
		{
			base.MapEntity(entityBuilder);

			entityBuilder.HasOne(x => x.MainInfo).WithOne()
				.HasForeignKey<DocumentMainInfo>(x => x.InstanceID)
				.HasPrincipalKey<Document>(x => x.Id);

			entityBuilder.HasOne(x => x.System).WithOne()
				.HasForeignKey<DocumentSystemInfo>(x => x.InstanceID)
				.HasPrincipalKey<Document>(x => x.Id);

			entityBuilder.HasMany(x => x.Numbers).WithOne()
				.HasForeignKey(x => x.InstanceID)
				.HasPrincipalKey(x => x.Id);
		}
	}

	public class DocumentMapper : DocumentMapper<Document>
	{
		public DocumentMapper() : base(CardDocument.ID) { }
	}
}
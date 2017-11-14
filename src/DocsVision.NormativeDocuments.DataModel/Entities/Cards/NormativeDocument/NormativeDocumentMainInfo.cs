using System;

using DocsVision.Platform.DataModel.Entities;

namespace DocsVision.NormativeDocuments.DataModel.Entities
{
	public class NormativeDocumentMainInfo : BaseCardSectionRow // TODO: map to AdditionalPropertiesLND section
	{
		public string Number { get; set; }

		public DateTime? CommissioningDate { get; set; }

		public DateTime? CancellationDate { get; set; }

		public bool? IncludeCont { get; set; }

		public int? Hierarchy { get; set; }

		public string ApprovalNumber { get; set; }

		public string Version { get; set; }

		public string FileName { get; set; }

		public string CommentForInclude { get; set; }

		public Guid? TypeLND { get; set; }

		public Guid? Owner { get; set; }

		public Guid? ExternalOwner { get; set; }

		public Guid? Classification { get; set; }

		public Guid? ResponsibleForContr { get; set; }

		public Guid? ResponsibleForEx { get; set; }

		public virtual BaseUniversalItem ClassificationType { get; set; }

		public virtual BaseUniversalItem DocumentType { get; set; }
	}
}
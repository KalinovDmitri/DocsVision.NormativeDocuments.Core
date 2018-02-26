using System;

using DocsVision.Platform.DataModel.Entities;

namespace DocsVision.NormativeDocuments.DataModel.Entities
{
	public class NormativeDocumentMailingList : BaseCardSectionRow
	{
		public Guid? Unit { get; set; }

		public virtual StaffUnit MailingUnit { get; set; }
	}
}
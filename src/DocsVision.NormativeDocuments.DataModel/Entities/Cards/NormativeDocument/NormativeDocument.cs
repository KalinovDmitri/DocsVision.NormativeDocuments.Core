using System;
using System.Collections.Generic;

using DocsVision.Platform.DataModel.Entities;

namespace DocsVision.NormativeDocuments.DataModel.Entities
{
	public class NormativeDocument : Document
	{
		public virtual NormativeDocumentMainInfo NormativeInfo { get; set; }

		public virtual ICollection<NormativeDocumentApplication> Applications { get; set; }

		public virtual ICollection<NormativeDocumentHistory> History { get; set; }

		public virtual ICollection<NormativeDocumentSheduleHistory> SheduleHistory { get; set; }
	}
}
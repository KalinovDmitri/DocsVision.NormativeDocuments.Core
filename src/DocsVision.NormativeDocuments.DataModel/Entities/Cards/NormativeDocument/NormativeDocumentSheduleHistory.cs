using System;

using DocsVision.Platform.DataModel.Entities;

namespace DocsVision.NormativeDocuments.DataModel.Entities
{
	public class NormativeDocumentSheduleHistory : BaseCardSectionRow // TODO: map to HystoryPG section
	{
		public string NumberPG { get; set; }

		public DateTime? CancellationDate { get; set; } // TODO: map to CanSellationDate column

		public DateTime? DatePG { get; set; }

		public int? ChangeNumber { get; set; }

		public string Comment { get; set; }

		public Guid? TypeOfWork { get; set; }

		public virtual BaseUniversalItem WorkType { get; set; }
	}
}
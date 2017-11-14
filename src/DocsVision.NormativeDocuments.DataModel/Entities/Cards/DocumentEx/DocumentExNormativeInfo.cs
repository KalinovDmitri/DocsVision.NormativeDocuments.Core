using System;

using DocsVision.Platform.DataModel.Entities;

namespace DocsVision.NormativeDocuments.DataModel.Entities
{
	public class DocumentExNormativeInfo : BaseCardSectionRow // TODO: map to LNDSection section
	{
		public DateTime? ActDate { get; set; }

		public string Act { get; set; }

		public string Version { get; set; }

		public string DocumentType { get; set; } // TODO: map to TypeLND column

		public string Document { get; set; } // TODO: map to RD column
	}
}
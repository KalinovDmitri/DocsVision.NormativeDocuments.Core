using System;

using DocsVision.Platform.DataModel.Entities;

namespace DocsVision.NormativeDocuments.DataModel.Entities
{
	public class NormativeDocumentHistory : BaseCardSectionRow // TODO: map to HystoryLND section
	{
		public string Name { get; set; }

		public string ReferenceID { get; set; }

		public Guid? DocumentID { get; set; } // TODO: map to RD column

		public Guid? Type { get; set; }

		public int Number { get; set; }

		public DateTime? Date { get; set; }

		public string IdStrings { get; set; }

		public string DocumentInfo { get; set; } // TODO: map to RDId column
	}
}
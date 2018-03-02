using System;
using System.Collections.Generic;

namespace DocsVision.NormativeDocuments.Models
{
	public class ExportViewModel
	{
		public IEnumerable<KindViewModel> Kinds { get; set; }

		public string SelectedKind { get; set; }

		public DateTime? StartDate { get; set; }

		public DateTime? EndDate { get; set; }

		public ExportViewModel() { }
	}
}
using System;
using System.IO;

namespace DocsVision.NormativeDocuments.Models
{
	public class ExportResultModel
	{
		public Stream File { get; set; }

		public string ContentType { get; } = "application/xlsx";

		public string Name { get; set; }
	}
}
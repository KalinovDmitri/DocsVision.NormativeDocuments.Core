using System;

using DocsVision.Platform.DataModel.Entities;

namespace DocsVision.NormativeDocuments.DataModel.Entities
{
	public class NormativeDocumentApplication : BaseCardSectionRow // TODO: map to ApplicationLND section
	{
		public string Name { get; set; }

		public string FileName { get; set; }
	}
}
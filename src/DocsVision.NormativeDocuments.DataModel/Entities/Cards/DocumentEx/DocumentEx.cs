using System;

using DocsVision.Platform.DataModel.Entities;

namespace DocsVision.NormativeDocuments.DataModel.Entities
{
	public class DocumentEx : Document
	{
		public virtual DocumentExNormativeInfo NormativeInfo { get; set; }
	}
}
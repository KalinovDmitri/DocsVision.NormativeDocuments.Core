using System;

using DocsVision.Platform.DataModel.CardDefs;
using DocsVision.Platform.DataModel.Entities;

namespace DocsVision.Platform.DataModel.Mapping
{
	public sealed class DocumentSystemInfoMapper : BaseCardSystemInfoMapper<DocumentSystemInfo>
	{
		public DocumentSystemInfoMapper() : base(CardDocument.System.ID) { }
	}
}
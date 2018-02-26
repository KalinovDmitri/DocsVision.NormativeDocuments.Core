using System;

using DocsVision.Platform.DataModel.CardDefs;
using DocsVision.Platform.DataModel.Entities;

namespace DocsVision.Platform.DataModel.Mapping
{
	public sealed class DocumentNumberMapper : BaseCardNumberMapper<DocumentNumber>
	{
		public DocumentNumberMapper() : base(CardDocument.Numbers.ID) { }
	}
}
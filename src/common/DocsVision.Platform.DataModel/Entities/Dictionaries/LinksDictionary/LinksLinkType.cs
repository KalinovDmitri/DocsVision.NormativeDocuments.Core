using System;

namespace DocsVision.Platform.DataModel.Entities
{
	public class LinksLinkType : BaseCardSectionRow
	{
		public string LinkName { get; set; }

		public string DisplayName { get; set; }

		public string OppositeLinkName { get; set; }

		public string SyncTag { get; set; }

		public string IncomingName { get; set; }

		public string OutgoingName { get; set; }

		public string InternalName { get; set; }

		public bool? NotAvailable { get; set; }
	}
}
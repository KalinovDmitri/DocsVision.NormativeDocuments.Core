using System;

namespace DocsVision.Platform.DataModel.Entities
{
	public class StaffPosition : BaseCardSectionRow
	{
		public string Name { get; set; }

		public int Importance { get; set; }

		public string SyncTag { get; set; }

		public string Comments { get; set; }

		public string ShortName { get; set; }
	}
}
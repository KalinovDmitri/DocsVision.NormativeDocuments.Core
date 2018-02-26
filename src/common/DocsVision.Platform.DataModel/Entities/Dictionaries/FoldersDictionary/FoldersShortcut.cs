using System;

namespace DocsVision.Platform.DataModel.Entities
{
	public class FoldersShortcut : BaseCardSectionRow
	{
		public Guid? CardID { get; set; }

		public Guid? HardCardID { get; set; }

		public Guid? Mode { get; set; }

		public string Description { get; set; }

		public bool? Deleted { get; set; }

		public bool? Recalled { get; set; }

		public DateTime? CreationDateTime { get; set; }
	}
}
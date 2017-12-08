using System;
using System.Collections.Generic;

namespace DocsVision.Platform.DataModel.Entities
{
	public class FoldersFolder : BaseCardSectionRow
	{
		public string Name { get; set; }

		public FoldersFolderType? Type { get; set; }

		public FoldersFolderStyle? DefaultStyle { get; set; }

		public Guid? PropCardID { get; set; }

		public string Url { get; set; }

		public bool? Deleted { get; set; }

		public Guid? IconRef { get; set; }

		public int? Restrictions { get; set; }

		public Guid? DefaultViewID { get; set; }

		public Guid? RefID { get; set; }

		public bool? ViewCyclingEnabled { get; set; }

		public int? ViewCycleCount { get; set; }

		public int? Flags { get; set; }

		public Guid? DefaultTemplateID { get; set; }

		public int? RefreshTimeout { get; set; }

		public Guid? ExtTypeID { get; set; }

		public DateTime? CreateDate { get; set; }

		public string CreatedBy { get; set; }

		public virtual FoldersFolder ParentFolder { get; set; }

		public virtual ICollection<FoldersFolder> Folders { get; set; }

		public virtual ICollection<FoldersShortcut> Shortcuts { get; set; }
	}
}
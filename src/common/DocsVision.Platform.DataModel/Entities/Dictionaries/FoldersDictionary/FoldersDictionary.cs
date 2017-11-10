using System;
using System.Collections.Generic;

namespace DocsVision.Platform.DataModel.Entities
{
	public class FoldersDictionary : BaseDictionaryCard
	{
		public virtual ICollection<FoldersFolder> Folders { get; set; }
	}
}
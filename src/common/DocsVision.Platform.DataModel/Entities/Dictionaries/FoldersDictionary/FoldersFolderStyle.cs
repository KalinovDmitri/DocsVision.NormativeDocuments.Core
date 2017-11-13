using System;

namespace DocsVision.Platform.DataModel.Entities
{
	[Flags]
	public enum FoldersFolderStyle : int
	{
		None = 0,
		FolderView = 1,
		FolderCard = 2,
		FolderURL = 4,
		FolderDigest = 8
	}
}
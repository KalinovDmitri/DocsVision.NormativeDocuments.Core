using System;

namespace DocsVision.Platform.DataModel.Entities
{
	[Flags]
	public enum FoldersFolderType : int
	{
		None = 0,
		Regular = 1,
		Virtual = 4,
		Delegate = 8,
		System = 16
	}
}
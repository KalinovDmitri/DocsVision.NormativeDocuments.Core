using System;

namespace DocsVision.Platform.DataModel.Entities
{
	[Flags]
	public enum CardSectionFlags : int
	{
		None = 0,
		ContainsProperties = 1,
		AllowsConcurrentAccess = 2,
		NoSearch = 4,
		ItemsSelectable = 8,
		LogOptional = 16,
		NonCopyable = 32,
		SimpleSecurity = 64,
		ItemsPinned = 128,
		Dynamic = 256
	}
}
using System;

namespace DocsVision.Platform.DataModel.Entities
{
	[Flags]
	public enum CardTypeFlags : int
	{
		None = 0,
		Dictionary = 1,
		NonCreatable = 2,
		NonViewable = 4,
		NonSearchable = 8,
		ShowLinked = 16,
		NoLockOnOpen = 32,
		UIExtention = 64,
		NoHardShortcuts = 128,
		FolderCard = 256,
		AlwaysRead = 512,
		Copyable = 1024,
		SimpleSecurity = 2048,
		CanBeTemplate = 4096,
		NonDeletable = 8192,
		ItemsSelectable = 16384,
		CustomXmlExport = 32768,
		Restricted = 65536,
		DeleteRestricted = 131072,
		NonArchivable = 16777216,
		NonReplicable = 33554432,
		ReplicateTemplatesOnly = 67108864,
		ReplicationStatus = 134217728,
		UseExtensionInAccessCheck = 536870912,
		CachingRestricted = 1073741824
	}
}
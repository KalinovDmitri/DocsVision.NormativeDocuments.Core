using System;

namespace DocsVision.Platform.DataModel.Entities
{
	public sealed class CardLibrary : AbstractEntity
	{
		public string Alias { get; set; }

		public int Version { get; set; }

		public int SysVersion { get; set; }

		public string ControlInfo { get; set; }

		public Guid? MsiProductCode { get; set; }

		public string MsiPackageName { get; set; }

		public Guid? MsiPatchCode { get; set; }

		public string MsiPatchName { get; set; }

		public string MsiTransformName { get; set; }
	}
}
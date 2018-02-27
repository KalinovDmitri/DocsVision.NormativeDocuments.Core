using System;
using System.Collections.Generic;

namespace DocsVision.Platform.DataModel.Entities
{
	public class KindsCardKind : BaseCardSectionRow
	{
		public string Digest { get; set; }

		public string Name { get; set; }

		public bool? UseOwnLayouts { get; set; }

		public bool? UseOwnSettings { get; set; }

		public bool? UseOwnExtendedSettings { get; set; }

		public bool? NotAvailable { get; set; }

		public Guid? Script { get; set; }

		public string ScriptProtect { get; set; }
		
		public virtual ICollection<KindsCardKind> Kinds { get; set; }
	}
}
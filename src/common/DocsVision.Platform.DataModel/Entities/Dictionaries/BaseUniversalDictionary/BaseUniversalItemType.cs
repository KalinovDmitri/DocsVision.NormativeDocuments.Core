using System;
using System.Collections.Generic;

namespace DocsVision.Platform.DataModel.Entities
{
	public class BaseUniversalItemType : BaseCardSectionRow
	{
		public string Name { get; set; }

		public string Description { get; set; }

		public bool? NotAvailable { get; set; }

		public bool? Locked { get; set; }

		public Guid? ItemKind { get; set; }

		public bool? UseOrder { get; set; }

		public string UserSettings { get; set; }

		public bool? ItemKindSpecified { get; set; }

		public virtual BaseUniversalItemType ParentType { get; set; }

		public virtual ICollection<BaseUniversalItemType> ChildTypes { get; set; }

		public virtual ICollection<BaseUniversalItem> Items { get; set; }
	}
}
using System;
using System.Collections.Generic;

namespace DocsVision.Platform.DataModel.Entities
{
	public class StaffUnit : BaseCardSectionRow
	{
		public string Name { get; set; }

		public Guid? Manager { get; set; }

		public string Comments { get; set; }

		public virtual StaffEmployee UnitManager { get; set; }

		public virtual StaffUnit ParentUnit { get; set; }

		public virtual ICollection<StaffUnit> ChildUnits { get; set; }

		public virtual ICollection<StaffEmployee> Employees { get; set; }
	}
}
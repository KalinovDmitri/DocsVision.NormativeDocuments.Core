using System;
using System.Collections.Generic;

namespace DocsVision.Platform.DataModel.Entities
{
	public class StaffDictionary : BaseDictionaryCard
	{
		public virtual ICollection<StaffUnit> Units { get; set; }
	}
}
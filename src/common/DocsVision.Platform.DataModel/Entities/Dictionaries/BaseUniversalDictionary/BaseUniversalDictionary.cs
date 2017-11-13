using System;
using System.Collections.Generic;

namespace DocsVision.Platform.DataModel.Entities
{
	public class BaseUniversalDictionary : BaseDictionaryCard
	{
		public virtual ICollection<BaseUniversalItemType> ItemTypes { get; set; }
	}
}
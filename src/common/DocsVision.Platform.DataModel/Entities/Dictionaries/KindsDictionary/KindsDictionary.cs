using System;
using System.Collections.Generic;

namespace DocsVision.Platform.DataModel.Entities
{
	public class KindsDictionary : BaseDictionaryCard
	{
		public virtual ICollection<KindsCardType> CardTypes { get; set; }
	}
}
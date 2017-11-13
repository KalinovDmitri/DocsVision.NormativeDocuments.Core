using System;
using System.Collections.Generic;

namespace DocsVision.Platform.DataModel.Entities
{
	public class LinksDictionary : BaseDictionaryCard
	{
		public virtual ICollection<LinksLinkType> LinkTypes { get; set; }
	}
}
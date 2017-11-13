using System;
using System.Collections.Generic;

namespace DocsVision.Platform.DataModel.Entities
{
	public class ReferenceList : BaseSystemCard
	{
		public virtual ICollection<ReferenceListReference> References { get; set; }
	}
}
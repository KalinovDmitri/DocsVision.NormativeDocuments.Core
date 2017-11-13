using System;
using System.Collections.Generic;

namespace DocsVision.Platform.DataModel.Entities
{
	public class ReferenceList : BaseCard
	{
		public virtual ICollection<ReferenceListReference> References { get; set; }
	}
}
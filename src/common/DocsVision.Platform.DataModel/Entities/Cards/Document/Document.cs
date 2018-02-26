using System;
using System.Collections.Generic;

namespace DocsVision.Platform.DataModel.Entities
{
	public class Document : BaseCard
	{
		public virtual DocumentMainInfo MainInfo { get; set; }

		public virtual ICollection<DocumentNumber> Numbers { get; set; }

		public virtual DocumentSystemInfo System { get; set; }
	}
}
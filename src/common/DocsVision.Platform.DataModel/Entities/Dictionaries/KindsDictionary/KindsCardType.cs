using System;
using System.Collections.Generic;

namespace DocsVision.Platform.DataModel.Entities
{
	public class KindsCardType : BaseCardSectionRow
	{
		public Guid CardTypeId { get; set; }

		public string HelpURL { get; set; }

		public string HelpTopic { get; set; }

		public ICollection<KindsCardKind> Kinds { get; set; }
	}
}
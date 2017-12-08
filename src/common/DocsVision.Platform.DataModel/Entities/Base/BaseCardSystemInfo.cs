using System;

namespace DocsVision.Platform.DataModel.Entities
{
	public class BaseCardSystemInfo : BaseCardSectionRow
	{
		public Guid? Kind { get; set; }

		public Guid? State { get; set; }
	}
}
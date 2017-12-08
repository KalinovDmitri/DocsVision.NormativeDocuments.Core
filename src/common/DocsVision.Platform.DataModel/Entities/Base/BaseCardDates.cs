using System;

namespace DocsVision.Platform.DataModel.Entities
{
	public class BaseCardDates : AbstractVersionedEntity
	{
		public DateTime? CreationDateTime { get; set; }

		public DateTime? ChangeDateTime { get; set; }
	}
}
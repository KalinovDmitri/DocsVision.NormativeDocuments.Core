using System;

namespace DocsVision.Platform.DataModel.Entities
{
	public class BaseCardNumber : BaseCardSectionRow
	{
		public Guid? NumericPart { get; set; }

		public string Number { get; set; }
	}
}
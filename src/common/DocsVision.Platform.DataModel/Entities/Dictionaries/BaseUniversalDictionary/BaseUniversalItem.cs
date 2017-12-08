using System;

namespace DocsVision.Platform.DataModel.Entities
{
	public class BaseUniversalItem : BaseCardSectionRow
	{
		public string Name { get; set; }

		public string Description { get; set; }

		public bool? NotAvailable { get; set; }

		public int? Order { get; set; }

		public Guid? ItemCard { get; set; }
	}
}
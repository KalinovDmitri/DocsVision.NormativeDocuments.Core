using System;

namespace DocsVision.Platform.DataModel.Entities
{
	public class CardSection : AbstractEntity
	{
		public string Alias { get; set; }

		public Guid ParentSectionID { get; set; }

		public Guid CardTypeID { get; set; }

		public short SecurityType { get; set; }

		public bool UserDependent { get; set; }

		public bool Extended { get; set; }

		public int NestLevel { get; set; }

		public CardSectionType Type { get; set; }

		public CardSectionFlags Flags { get; set; }

		public bool IsDynamic { get; set; }

		public bool New { get; set; }
		
		public virtual CardSection ParentSection { get; set; }

		public virtual CardType ParentType { get; set; }
	}
}
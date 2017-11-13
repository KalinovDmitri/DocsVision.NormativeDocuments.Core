using System;
using System.Collections.Generic;

namespace DocsVision.Platform.DataModel.Entities
{
	public class CardType : AbstractVersionedEntity
	{
		public string Alias { get; set; }

		public int Version { get; set; }

		public int SysVersion { get; set; }

		public Guid LibraryID { get; set; }

		public string ControlInfo { get; set; }

		public CardTypeFlags Options { get; set; }

		public CardTypeFetchMode FetchMode { get; set; }

		public Guid SDID { get; set; }

		public virtual CardLibrary Library { get; set; }

		public virtual SecurityInfo Security { get; set; }

		public virtual ICollection<CardSection> Sections { get; set; }
	}
}
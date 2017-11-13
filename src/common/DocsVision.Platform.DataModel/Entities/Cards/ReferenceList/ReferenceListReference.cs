using System;

namespace DocsVision.Platform.DataModel.Entities
{
	public class ReferenceListReference : BaseCardSectionRow
	{
		public Guid? Author { get; set; }

		public Guid? Type { get; set; }

		public Guid? Card { get; set; }

		public DateTime? CreationDate { get; set; }

		public string URL { get; set; }

		public string Description { get; set; }

		public Guid? Folder { get; set; }

		public Guid? CardHardLink { get; set; }

		public Guid? CardType { get; set; }

		public virtual StaffEmployee LinkAuthor { get; set; }

		public virtual LinksLinkType LinkType { get; set; }

		public virtual FoldersFolder LinkedFolder { get; set; }
	}
}
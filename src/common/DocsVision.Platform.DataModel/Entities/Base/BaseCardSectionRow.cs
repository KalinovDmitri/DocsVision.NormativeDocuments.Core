using System;

namespace DocsVision.Platform.DataModel.Entities
{
	public class BaseCardSectionRow : AbstractVersionedEntity
	{
		public Guid OwnServerID { get; set; }

		public Guid? ChangeServerID { get; set; }

		public Guid InstanceID { get; set; }

		public Guid ParentRowID { get; set; }

		public Guid ParentTreeRowID { get; set; }
	}
}
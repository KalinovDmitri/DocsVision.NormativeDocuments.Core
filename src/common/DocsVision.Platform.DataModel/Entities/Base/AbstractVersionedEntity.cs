using System;

namespace DocsVision.Platform.DataModel.Entities
{
	public abstract class AbstractVersionedEntity : AbstractEntity
	{
		public byte[] Timestamp { get; set; }
	}
}
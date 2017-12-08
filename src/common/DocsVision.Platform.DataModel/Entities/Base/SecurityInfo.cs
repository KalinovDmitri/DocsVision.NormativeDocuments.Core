using System;

namespace DocsVision.Platform.DataModel.Entities
{
	public class SecurityInfo : AbstractEntity
	{
		public int Hash { get; set; }

		public string SecurityDesc { get; set; }
	}
}
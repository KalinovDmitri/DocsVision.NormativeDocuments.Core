using System;

namespace DocsVision.Platform.DataModel.Entities
{
	public abstract class BaseSystemCard : BaseCard
	{
		public override BaseCardSystemInfo SystemInfo
		{
			get => null;
			set { }
		}
	}
}
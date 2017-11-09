using System;

namespace DocsVision.Platform.DataModel.Entities
{
	[Flags]
	public enum CardTypeFetchMode : int
	{
		None = 0,
		Card = 1,
		Section = 2,
		SubSection = 4,
		Level = 8,
		Row = 16
	}
}
using System;

namespace DocsVision.Platform.DataModel
{
	public interface ICardMapper : IEntityMapper
	{
		Type CardType { get; }

		Guid CardTypeID { get; }
	}
}
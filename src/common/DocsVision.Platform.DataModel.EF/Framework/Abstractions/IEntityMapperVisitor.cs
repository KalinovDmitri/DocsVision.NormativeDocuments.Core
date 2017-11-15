using System;

namespace DocsVision.Platform.DataModel
{
	public interface IEntityMapperVisitor
	{
		void VisitCard(ICardMapper cardMapper);
	}
}
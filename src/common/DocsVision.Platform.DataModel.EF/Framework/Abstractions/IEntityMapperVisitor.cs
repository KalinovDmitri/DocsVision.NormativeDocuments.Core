using System;

namespace DocsVision.Platform.DataModel
{
	public interface IEntityMapperVisitor
	{
		void Visit(ICardMapper cardMapper);
	}
}
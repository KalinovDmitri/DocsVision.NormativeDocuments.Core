using System;

namespace DocsVision.Platform.DataModel
{
	public interface IMetadataProvider
	{
		Guid GetSectionID(Guid cardTypeID, string sectionAlias);
	}
}
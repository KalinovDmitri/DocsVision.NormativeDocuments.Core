using System;

namespace DocsVision.NormativeDocuments.Providers
{
	public interface IApplicationUserProvider
	{
		bool IsUserRegistered(string userName, string password);
	}
}
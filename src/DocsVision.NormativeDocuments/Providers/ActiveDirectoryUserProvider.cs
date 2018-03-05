using System;

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using Novell.Directory.Ldap;

using DocsVision.NormativeDocuments.Configuration;

namespace DocsVision.NormativeDocuments.Providers
{
	internal class ActiveDirectoryUserProvider : IApplicationUserProvider
	{
		#region Fields

		private readonly ActiveDirectoryConfiguration _adConfig;

		private readonly ILogger _logger;
		#endregion

		#region Constructors

		public ActiveDirectoryUserProvider(IOptions<ActiveDirectoryConfiguration> activeDirectoryOptions, ILogger<ActiveDirectoryUserProvider> logger)
		{
			_adConfig = activeDirectoryOptions.Value;
			_logger = logger;
		}
		#endregion

		#region IApplicationUserProvider implementation

		public bool IsUserRegistered(string userName, string password)
		{
			bool result = false;
			LdapConnection connection = null;

			try
			{
				connection = new LdapConnection();

				connection.Connect(_adConfig.Hostname, _adConfig.Port);
				connection.Bind(userName, password);

				result = true;
			}
			catch (Exception exc)
			{
				_logger.LogError(exc, "Error occured during connect to Active Directory server.");
				throw;
			}
			finally
			{
				connection?.Disconnect();
			}

			return result;
		}
		#endregion
	}
}
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;

using DocsVision.NormativeDocuments.Models;
using DocsVision.NormativeDocuments.Providers;

namespace DocsVision.NormativeDocuments.Services
{
	public class AccountService : ApplicationServiceBase
	{
		#region Fields

		private readonly IApplicationUserProvider _userProvider;
		#endregion

		#region Constructors

		public AccountService(IApplicationUserProvider userProvider, ILogger logger) : base(logger)
		{
			_userProvider = userProvider;
		}
		#endregion

		#region Public class methods

		public bool IsSignedIn(ClaimsPrincipal currentUser)
		{
			var idClaim = currentUser?.FindFirst(ClaimTypes.NameIdentifier);

			Guid userId;
			return (idClaim != null) && Guid.TryParse(idClaim.Value, out userId);
		}

		public string GetUserName(ClaimsPrincipal currentUser)
		{
			var nameClaim = currentUser?.FindFirst(ClaimTypes.Name);
			return nameClaim?.Value ?? string.Empty;
		}

		public async Task<ClaimsPrincipal> LoginAsync(LoginViewModel loginModel, string authenticationType)
		{
			await Task.Delay(500);

			if (_userProvider.IsUserRegistered(loginModel.Username, loginModel.Password))
			{
				ClaimsPrincipal userClaims = new ClaimsPrincipal();

				ClaimsIdentity userIdentity = new ClaimsIdentity(authenticationType);

				userIdentity.AddClaim(new Claim(ClaimTypes.Name, loginModel.Username, ClaimValueTypes.String));
				userIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString(), ClaimValueTypes.String));

				userClaims.AddIdentity(userIdentity);

				return userClaims;
			}

			return null;
		}
		#endregion
	}
}
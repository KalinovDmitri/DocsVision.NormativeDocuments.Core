using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

using DocsVision.NormativeDocuments.Models;

namespace DocsVision.NormativeDocuments.Services
{
	public class AccountService : ApplicationServiceBase
	{
		#region Constructors

		public AccountService() : base() { }
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

			ClaimsPrincipal userClaims = new ClaimsPrincipal(); // TODO: try get user claims using IAccountService & LoginViewModel

			ClaimsIdentity userIdentity = new ClaimsIdentity(authenticationType);

			userIdentity.AddClaim(new Claim(ClaimTypes.Name, loginModel.Username, ClaimValueTypes.String));
			userIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString(), ClaimValueTypes.String));

			userClaims.AddIdentity(userIdentity);

			return userClaims;
		}
		#endregion
	}
}
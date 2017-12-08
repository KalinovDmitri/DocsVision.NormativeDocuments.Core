using System;
using System.Security.Claims;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using DocsVision.NormativeDocuments.Models;

namespace DocsVision.NormativeDocuments.Controllers
{
	[Authorize]
	public class AccountController : Controller
	{
		#region Action methods

		[AllowAnonymous]
		[HttpGet]
		public async Task<IActionResult> Login(string returnUrl = null)
		{
			await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

			ViewData["ReturnUrl"] = returnUrl;
			return View();
		}

		[AllowAnonymous]
		[HttpPost]
		public async Task<IActionResult> Login([FromForm] LoginViewModel model, string returnUrl)
		{
			if (ModelState.IsValid)
			{
				ClaimsPrincipal userClaims = new ClaimsPrincipal(); // TODO: try get user claims using IAccountService & LoginViewModel

				ClaimsIdentity userIdentity = new ClaimsIdentity();
				userIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString(), ClaimValueTypes.String));
				userClaims.AddIdentity(userIdentity);

				await HttpContext.SignInAsync(userClaims);

				return RedirectToLocal(returnUrl);
			}

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Logout()
		{
			await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

			return RedirectToAction(nameof(Login));
		}
		#endregion

		#region Helpers

		private IActionResult RedirectToLocal(string returnUrl)
		{
			if (returnUrl != null && Url.IsLocalUrl(returnUrl))
			{
				return LocalRedirect(returnUrl);
			}
			else
			{
				return RedirectToAction(nameof(HomeController.Index), "Home");
			}
		}
		#endregion
	}
}
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
		public IActionResult Login()
		{
			return View();
		}

		[AllowAnonymous]
		[HttpPost]
		public async Task<IActionResult> Login([FromForm] LoginViewModel model, string returnUrl)
		{
			if (ModelState.IsValid)
			{
				ClaimsPrincipal userClaims = new ClaimsPrincipal(); // TODO: try get user claims using IAccountService & LoginViewModel
				await HttpContext.SignInAsync(userClaims);

				return LocalRedirect(returnUrl);
			}

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Logout()
		{
			await HttpContext.SignOutAsync();

			return RedirectToAction(nameof(Login));
		}
		#endregion
	}
}
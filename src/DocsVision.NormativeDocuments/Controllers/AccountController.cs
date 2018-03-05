using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using DocsVision.NormativeDocuments.Models;
using DocsVision.NormativeDocuments.Services;

namespace DocsVision.NormativeDocuments.Controllers
{
	public class AccountController : ApplicationControllerBase
	{
		#region Fields

		private AccountService _accountService;
		#endregion

		#region Constructors

		public AccountController(AccountService accountService) : base()
		{
			_accountService = accountService;
		}
		#endregion

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
				var userClaims = await _accountService.LoginAsync(model, CookieAuthenticationDefaults.AuthenticationScheme);
				if (userClaims != null)
				{
					await HttpContext.SignInAsync(userClaims, new AuthenticationProperties
					{
						AllowRefresh = true,
						IsPersistent = true
					});

					return RedirectToLocal(returnUrl);
				}
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
	}
}
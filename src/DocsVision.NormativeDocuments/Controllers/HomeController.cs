using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using DocsVision.NormativeDocuments.Services;

namespace DocsVision.NormativeDocuments.Controllers
{
	public class HomeController : ApplicationControllerBase
	{
		#region Fields

		private AccountService _accountService;
		#endregion

		#region Constructors

		public HomeController(AccountService accountService) : base()
		{
			_accountService = accountService;
		}
		#endregion

		#region Action methods

		[AllowAnonymous]
		[HttpGet]
		public IActionResult Index()
		{
			if (_accountService.IsSignedIn(User))
			{
				return View();
			}

			return RedirectToAction(nameof(AccountController.Login), "Account");
		}
		#endregion
	}
}
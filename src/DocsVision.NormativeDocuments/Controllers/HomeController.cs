using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DocsVision.NormativeDocuments.Controllers
{
	[Authorize]
	public class HomeController : Controller
	{
		#region Action methods

		[AllowAnonymous]
		[HttpGet]
		public IActionResult Index()
		{
			if (User?.FindFirst(ClaimTypes.NameIdentifier) != null) // TODO: check is user authenticated using IAccountService
			{
				return View();
			}

			return RedirectToAction("Login", "Account");
		}
		#endregion
	}
}
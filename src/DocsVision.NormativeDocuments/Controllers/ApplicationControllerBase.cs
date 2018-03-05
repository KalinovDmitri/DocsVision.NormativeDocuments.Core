using System;
using System.Collections.Generic;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DocsVision.NormativeDocuments.Controllers
{
	[Authorize]
	public abstract class ApplicationControllerBase : Controller
	{
		#region Constructors

		protected internal ApplicationControllerBase() { }
		#endregion

		#region Helper methods

		protected IActionResult RedirectToLocal(string returnUrl)
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
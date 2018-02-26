using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

namespace DocsVision.NormativeDocuments.Controllers
{
	public class HomeController : Controller
	{
		#region Action methods

		public IActionResult Index()
		{
			return View();
		}
		#endregion
	}
}
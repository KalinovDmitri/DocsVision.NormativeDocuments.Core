using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DocsVision.NormativeDocuments.Controllers
{
	public class NormativeDocumentsController : Controller
	{
		#region Action methods

		[HttpGet]
		public IActionResult Export()
		{
			return View();
		}
		#endregion
	}
}
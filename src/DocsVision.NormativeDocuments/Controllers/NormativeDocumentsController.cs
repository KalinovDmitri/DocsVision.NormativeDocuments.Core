using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using DocsVision.NormativeDocuments.Models;
using DocsVision.NormativeDocuments.Services;

namespace DocsVision.NormativeDocuments.Controllers
{
	public class NormativeDocumentsController : ApplicationControllerBase
	{
		#region Fields

		public NormativeDocumentsService _documentService;
		#endregion

		#region Constructors

		public NormativeDocumentsController(NormativeDocumentsService documentService)
		{
			_documentService = documentService;
		}
		#endregion

		#region Action methods

		[HttpGet]
		public IActionResult Export()
		{
			var model = _documentService.CreateExportModel();

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Export([FromForm] ExportViewModel model)
		{
			if (ModelState.IsValid)
			{
				var exportResult = await _documentService.ExportAsync(model);
				if (exportResult.IsSuccess)
				{
					var resultModel = exportResult.Payload;

					return File(resultModel.File, resultModel.ContentType, resultModel.Name);
				}
			}

			return View(model);
		}
		#endregion
	}
}
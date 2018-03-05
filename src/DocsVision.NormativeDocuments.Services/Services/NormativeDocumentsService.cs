using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;

using DocsVision.NormativeDocuments.Models;

namespace DocsVision.NormativeDocuments.Services
{
	public class NormativeDocumentsService : ApplicationServiceBase
	{
		#region Constructors

		public NormativeDocumentsService(ILogger logger) : base(logger) { }
		#endregion

		#region Public class methods

		public ExportViewModel CreateExportModel()
		{
			var kinds = new List<KindViewModel>
			{
				new KindViewModel { Id = "community", Name = "ЛНД Общества" },
				new KindViewModel { Id = "company", Name = "ЛНД Компании" }
			};

			var model = new ExportViewModel
			{
				Kinds = kinds
			};

			return model;
		}

		public async Task<OperationResult<ExportResultModel>> ExportAsync(ExportViewModel model)
		{
			await Task.Delay(100);

			var resultModel = new ExportResultModel
			{
				File = new MemoryStream(1024),
				Name = model.SelectedKind + ".xlsx"
			};
			return new OperationResult<ExportResultModel>(resultModel);
		}
		#endregion
	}
}
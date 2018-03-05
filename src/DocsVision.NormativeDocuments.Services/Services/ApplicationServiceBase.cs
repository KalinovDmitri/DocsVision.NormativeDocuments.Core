using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;

namespace DocsVision.NormativeDocuments.Services
{
	public abstract class ApplicationServiceBase
	{
		#region Fields

		protected readonly ILogger _logger;
		#endregion

		#region Constructors

		protected internal ApplicationServiceBase(ILogger logger)
		{
			_logger = logger;
		}
		#endregion
	}
}
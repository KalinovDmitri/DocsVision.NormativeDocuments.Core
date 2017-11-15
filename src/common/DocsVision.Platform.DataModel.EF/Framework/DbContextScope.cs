using System;

using Microsoft.EntityFrameworkCore;

namespace DocsVision.Platform.DataModel
{
	internal class DbContextScope<TContext> where TContext : DbContext
	{
		private IServiceProvider _serviceProvider;

		public DbContextScope(IServiceProvider serviceProvider)
		{
			_serviceProvider = serviceProvider;
		}

		public TContext GetContext()
		{
			var context = _serviceProvider.GetService(typeof(TContext));
			return (TContext)context;
		}
	}
}
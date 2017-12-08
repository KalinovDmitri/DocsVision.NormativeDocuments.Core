using System;

using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.EntityFrameworkCore
{
	internal class DbContextScope<TContext> : IDbContextScope<TContext> where TContext : DbContext
	{
		private readonly IServiceProvider _serviceProvider;

		public DbContextScope(IServiceProvider serviceProvider)
		{
			_serviceProvider = serviceProvider;
		}

		public TContext GetContext()
		{
			return _serviceProvider.GetService<TContext>();
		}
	}
}
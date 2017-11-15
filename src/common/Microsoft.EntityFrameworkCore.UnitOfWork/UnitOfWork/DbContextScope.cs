using System;

using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.EntityFrameworkCore.UnitOfWork
{
	internal class DbContextScope<TContext> : IDbContextScope where TContext : DbContext
	{
		private readonly IServiceProvider _serviceProvider;

		public DbContextScope(IServiceProvider serviceProvider)
		{
			_serviceProvider = serviceProvider;
		}

		public DbContext GetContext()
		{
			return _serviceProvider.GetService<TContext>();
		}
	}
}
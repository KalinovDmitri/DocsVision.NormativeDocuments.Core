using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.UnitOfWork;

namespace Microsoft.Extensions.DependencyInjection
{
	public static class ServiceCollectionExtensions
	{
		public static IServiceCollection AddDbContextScope<TContext>(this IServiceCollection services) where TContext : DbContext
		{
			services.AddSingleton<IDbContextScope<TContext>, DbContextScope<TContext>>();

			return services;
		}

		public static IServiceCollection AddUnitOfWork<TContext>(this IServiceCollection services) where TContext : DbContext
		{
			services.AddSingleton<IDbContextScope<TContext>, DbContextScope<TContext>>();
			services.AddSingleton<IUnitOfWork, UnitOfWork<TContext>>();

			return services;
		}
	}
}
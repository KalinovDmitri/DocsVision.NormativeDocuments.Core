using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DocsVision.Platform.DataModel
{
	public static class DocsVisionServiceCollectionExtensions
	{
		public static IServiceCollection AddDocsVisionContext<TContext>(this IServiceCollection services,
			Func<IServiceProvider, DocsVisionSchema> schemaFactory,
			Action<DbContextOptionsBuilder> optionsAction,
			ServiceLifetime contextLifetime = ServiceLifetime.Scoped,
			ServiceLifetime optionsLifetime = ServiceLifetime.Scoped) where TContext : DocsVisionContext
		{
			services.AddSingleton(schemaFactory);
			services.AddTransient<IMetadataProvider, MetadataProvider>();

			services.AddDbContext<MetadataContext>(optionsAction, ServiceLifetime.Transient, ServiceLifetime.Transient);
			services.AddDbContext<TContext>(optionsAction, contextLifetime, optionsLifetime);
			
			return services;
		}
	}
}
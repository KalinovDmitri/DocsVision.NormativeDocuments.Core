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
			services.AddDbContextScope<MetadataContext>();

			services.AddSingleton(schemaFactory);
			services.AddSingleton<IMetadataProvider, MetadataProvider>();

			services.AddDbContext<MetadataContext>(optionsAction, contextLifetime, optionsLifetime);
			services.AddDbContext<TContext>(optionsAction, contextLifetime, optionsLifetime);
			
			return services;
		}
	}
}
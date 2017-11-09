using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DocsVision.NormativeDocuments
{
	public class Startup
	{
		#region Fields and properties

		public IConfiguration Configuration { get; }
		#endregion

		#region Constructors

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}
		#endregion

		#region Public class methods

		public void ConfigureServices(IServiceCollection services)
		{
			ConfigureDatabase(services);
			ConfigureAuthentication(services);
			
			services.AddMvc();
		}
		
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseDatabaseErrorPage();
				app.UseBrowserLink();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
			}

			app.UseStaticFiles();
			app.UseAuthentication();
			app.UseMvc(ConfigureRoutes);
		}
		#endregion

		#region Private class methods

		private void ConfigureDatabase(IServiceCollection services)
		{

		}

		private void ConfigureAuthentication(IServiceCollection services)
		{

		}

		private void ConfigureRoutes(IRouteBuilder routeBuilder)
		{
			routeBuilder.MapRoute(
				name: "default",
				template: "{controller=Home}/{action=Index}/{id?}");
		}
		#endregion
	}
}

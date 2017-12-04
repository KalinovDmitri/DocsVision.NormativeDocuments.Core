using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
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
			services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
				.AddCookie(BuildCookieAuthenticationOptions);
		}

		private void BuildCookieAuthenticationOptions(CookieAuthenticationOptions options)
		{
			options.ClaimsIssuer = "DocsVision";
			options.LoginPath = new PathString("/Account/Login");
			options.LogoutPath = new PathString("/Account/Logout");
			options.ExpireTimeSpan = TimeSpan.FromDays(14.0);
			options.SlidingExpiration = true;
#if DEBUG
			options.Validate();
#endif
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

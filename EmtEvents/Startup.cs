using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Localization.Routing;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using EmtEvents.AppStartup.MicroServices.ApplicationServices;
using EmtEvents.AppStartup.WebApplication.ApplicationServices;
using EmtEvents.AppStartup.WebApplication.RequestPipeline;
using EmtEvents.Services.Configurations.AppSetting.Constants;
using EmtEvents.Settings.Cultures;
using TamTechSDK.Common.Services.ContentService.Brands.Models;
using TamTechSDK.Common.Services.ContentService.Categories.Models;
using TamTechSDK.Common.Services.Identity.Models;
using TamTechSDK.Common.Services.Identity.Models.Params;
using TamTechSDK.Web.Models.Admin.User;
using TamTechSDK.Web.Routing;
using TamTechSDK.Web.Services.Configurations.Cultures;
using Microsoft.AspNetCore.ResponseCompression;
using System.IO.Compression;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace EmtEvents
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {

            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLocalizationConfigurations();


            services.AddMvcConfigurations();

            services.Configure<GzipCompressionProviderOptions>(option =>
            {
                option.Level = CompressionLevel.Fastest;
            });

            services.AddResponseCompression(options =>
            {
                //options.Providers.Add<BrotliCompressionProvider>();

                options.EnableForHttps = true;
                options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[]
                {
                    "application/xml",
                    "text/xml",
                    "application/json",
                    "text/json",
                    "image/svg+xml",
                    "application/font-woff2",
                    "application/x-font-ttf",
                    "font/ttf",
                    "font/eot",
                    "font/otf",
                    "font/opentype"
                });


                //options.Providers.Add<BrotliCompressionProvider>();
                options.Providers.Add<GzipCompressionProvider>();

            });

            services.AddFiltersConfigurations();

            services.AddAuthenticationServicesConfigurations(Configuration);

            services.AddCommonServicesConfigurations(Configuration);

            services.AddMainServicesConfigurations(Configuration);

            services.AddBusinessLogicServicesConfigurations(Configuration);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            bool useMicroServices = Configuration.GetSection(AppSettings.WebApplicationSettings)
                                               .GetSection(AppSettings.WebApplication_UseMicroServices).Get<bool>();

            if (env.IsDevelopment())
            {
                // app.UseBrowserLink(); from web admin panel
                app.UseDeveloperExceptionPage();

                if (!useMicroServices)
                {

                    // identity self securing 
                    TamTechBackendSDK.IdentityService.Configurations.MigrateDbConfigurations identityMigrateDb =
                        new TamTechBackendSDK.IdentityService.Configurations.MigrateDbConfigurations
                        (
                            Configuration,
                            identityServiceSelfSecuringSectionName: $"{AppSettings.DirectBackendSDKsSettings}:{AppSettings.DirectBackendSDK_IdentityService_SelfSecuring}",
                            seedUsersAndRolesSettingsSectionName: $"{AppSettings.DirectBackendSDKsSettings}:{AppSettings.DirectBackendSDK_IdentityService_SeedUsersAndRoles}",
                            seedIdentityServerSettingsSectionName: $"{AppSettings.DirectBackendSDKsSettings}:{AppSettings.DirectBackendSDK_IdentityService_SeedIdentityServer}"
                        );
                    identityMigrateDb.SeedIdentityServerSettings(app);
                    identityMigrateDb.SeedIdentityServerUsersAndRoles(app);
                }
            }
            else
            {
                app.UseExceptionHandler("/error/500");
                app.UseHsts();
            }


            app.MigrateDB(Configuration);


            //app.UseHttpsRedirection();
            //app.UseStaticFiles();
            //app.UseCookiePolicy();

            var cachePeriod = env.IsDevelopment() ? "600" : "86400";
            app.UseStaticFiles(new StaticFileOptions
            {
                OnPrepareResponse = ctx =>
                {
                    ctx.Context.Response.Headers.Append("Cache-Control", $"public, max-age={cachePeriod}");
                }
            });
            app.UseResponseCompression();

            app.UseStatusCodePagesWithRedirects("/error/{0}");

            app.InitializeMapper();

            app.UseAuthentication();
            if (!useMicroServices)
            {
                app.UseIdentityServer();
            }


            //IList<System.Globalization.CultureInfo> supportedCultures = new List<System.Globalization.CultureInfo>
            //        {
            //            new System.Globalization.CultureInfo("en-US"),
            //            new System.Globalization.CultureInfo("ar-SA"),
            //        };

            //var localizationOptions = new RequestLocalizationOptions
            //{
            //    DefaultRequestCulture = new RequestCulture("en-US"),
            //    SupportedCultures = supportedCultures,
            //    SupportedUICultures = supportedCultures
            //};
            //var requestProvider = new RouteDataRequestCultureProvider();
            //localizationOptions.RequestCultureProviders.Insert(0, requestProvider);
            app.UseAppRouter(Configuration, new CultureManager().LocalizationOptions);
            // app.UseAppRouter(Configuration, localizationOptions);


        }
    }
}
//public class RouteConfig
//{
//    public static void RegisterRoutes(RouteCollection routes)
//    {
//        routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

//        routes.MapRoute(
//            name: "Default",
//            url: "{controller}/{action}/{id}",
//            defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
//            namespaces: new string[] { "Portal.Areas.PortalAdmin.Controllers" }
//        ).DataTokens.Add("Area", "PortalAdmin");
//    }
//}
/*
 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  Steps of Reference token  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
Actors: 
1 – Identity server. 
2 – API.		 (identity.api)
3 – Client.	(AdminPanel)

API:
In AddIdentityServerAuthentication method Add ApiSecret = "apisecret" option 

Client:
Set AccessTokenType = AccessTokenType.Reference via database.
Go to Clients table in identity server DB and set AccessTokenType  field (1) value.


Identity server: 
Go to ApiSecret table in identity server database and add new record 
{ApiResourceId = API Id (identity.api id), Type = "SharedSecret", Value = "apisecret".Sha256())}
 */

using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmtEvents.AppStartup.WebApplication.ApplicationServices
{
    public static class MvcServicesConfigurations
    {
        public static void AddMvcConfigurations(this IServiceCollection services)
        {


            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.Configure<RouteOptions>(options => options.LowercaseUrls = false);

            services.AddMvc()
               .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
               .SetCompatibilityVersion(CompatibilityVersion.Version_2_1).AddFluentValidation();
            services.AddPortableObjectLocalization(options => options.ResourcesPath = "Localization");
            services.AddMvcCore().AddJsonFormatters();



        }
    }
}

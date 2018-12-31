using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmtEvents.AppStartup.DirectBackendServices.ContentService.RequestPipeline
{
    public static class DevelopmentEnvironmentConfigurations
    {
        public static void ContentService_ConfigureDevelopmentEnvironment(this IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
        }
    }
}

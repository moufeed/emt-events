using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TamTechSDK.Common.Services.ContentService.Menus;

namespace EmtEvents
{
    public class Program
    {

        public static void Main(string[] args)
        {  
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false)
            .Build();

            return WebHost.CreateDefaultBuilder(args)
                .UseApplicationInsights()
                .UseUrls($"http://localhost:{config.GetValue<int>("Host:Port")}", $"https://localhost:{config.GetValue<int>("Host:Port") + 1}")
                .UseKestrel()
                .UseIISIntegration()
                .UseStartup<Startup>();
        }


    }
}

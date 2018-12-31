using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using EmtEvents.Services.Configurations.AppSetting.Constants;
using TamTechBackendSDK.ContentService.Repositories.CosmosRepositories;
using TamTechBackendSDK.ContentService.SQL;

namespace EmtEvents.AppStartup.DirectBackendServices.ContentService.RequestPipeline
{
    public static class MigrationDbConfigurations
    {
        public static void ContentService_MigrateDB(this IApplicationBuilder app, IConfiguration configuration)
        {
            var dbType = configuration.GetSection(AppSettings.DirectBackendSDKsSettings)
                                      .GetSection(AppSettings.DirectBackendSDK_ContetntService_UseDatabase).Get<string>();

            switch (dbType)
            {
                case "SQLServer":
                    //using (var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
                    //{ 
                    //    var context = scope.ServiceProvider.GetRequiredService<ContentDbContext>(); 
                    //    context.Database.Migrate();
                    //}
                    break;
                case "Cosmos":
                    var MigrateDatabase = configuration.GetSection(AppSettings.DirectBackendSDKsSettings)
                                                       .GetValue<bool>(AppSettings.DirectBackendSDK_ContentService_MigrateDatabase);

                    if (MigrateDatabase)
                    {

                        var cosmosMigration = app.ApplicationServices.GetService<CosmosMigration>();
                        cosmosMigration.MigrateAsync().Wait();

                        //var SeedDatabase = Configuration.GetValue<bool>("SeedDatabase");
                        //if (SeedDatabase)
                        //{
                        //    cosmosRepository.SeedAsync().Wait();
                        //}

                    }
                    break;
            }



        }
    }
}

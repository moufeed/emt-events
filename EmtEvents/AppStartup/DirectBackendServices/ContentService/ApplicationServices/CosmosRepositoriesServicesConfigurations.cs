using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TamTech.Common.Models.Settings;
using EmtEvents.Services.Configurations.AppSetting.Constants;
using TamTechBackendSDK.ContentService.Repositories;
using TamTechBackendSDK.ContentService.Repositories.CosmosRepositories;

namespace EmtEvents.AppStartup.DirectBackendServices.ContentService.ApplicationServices
{

    public static class CosmosRepositoriesServicesConfigurations
    {
        public static void ContentService_AddCosmosRepositoriesConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient(settings => configuration.GetSection(AppSettings.DirectBackendSDKsSettings)// first step (CosmosDatabase)
                                    .GetSection(AppSettings.DirectBackendSDK_ContentService_CosmosDatabaseSettings).Get<CosmosDatabaseSettings>());
            services.AddTransient(settings => configuration.GetSection(AppSettings.DirectBackendSDKsSettings)// second step (CosmosDatabase)
                                      .GetSection(AppSettings.DirectBackendSDK_ContentService_CosmosCollectionsSettings).Get<CosmosCollectionsSettings>());
            services.AddTransient<CosmosMigration, CosmosMigration>();
            services.AddTransient<IPageRepository, CosmosPageRepository>();// third step (CosmosDatabase) 
            services.AddTransient(typeof(IRepository<>), typeof(DocumentDBRepository<>));
            services.AddTransient<IProductRepository, CosmosProductRepository>();
            services.AddTransient<ICategoryRepository, CosmosCategoryRepository>();
            services.AddTransient<IBrandRepository, CosmosBrandRepository>();
            services.AddTransient<IMenuRepository, CosmosMenuRepository>();
        }

    }
}

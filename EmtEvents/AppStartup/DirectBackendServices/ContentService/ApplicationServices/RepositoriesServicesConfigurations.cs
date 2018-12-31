using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TamTech.Common.Models.Settings;
using EmtEvents.Services.Configurations.AppSetting.Constants;
using TamTechBackendSDK.ContentService.Repositories;
using TamTechBackendSDK.ContentService.Repositories.CosmosRepositories;

namespace EmtEvents.AppStartup.DirectBackendServices.ContentService.ApplicationServices
{

    public static class RepositoriesServicesConfigurations
    {
        public static void DirectBackendServices_ContentService_AddRepositoriesConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            var dbType = configuration.GetSection(AppSettings.DirectBackendSDKsSettings)
                                    .GetSection(AppSettings.DirectBackendSDK_ContetntService_UseDatabase).Get<string>();
            switch (dbType)
            {
                case "SQLServer":
                    services.ContentService_AddEFCoreRepositoriesConfigurations(configuration);
                    break;
                case "Cosmos":
                    services.ContentService_AddCosmosRepositoriesConfigurations(configuration);
                    break;
            }

        }

    }
}

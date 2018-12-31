using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using EmtEvents.AppStartup.DirectBackendServices.ContentService.ApplicationServices;
using EmtEvents.AppStartup.DirectBackendServices.EmailService;
using EmtEvents.AppStartup.DirectBackEndServices.FilesServices;
using EmtEvents.AppStartup.MicroServices.ApplicationServices;
using EmtEvents.Services.Configurations.AppSetting.Constants;

namespace EmtEvents.AppStartup.WebApplication.ApplicationServices
{
    public static class MainServicesConfigurations
    {
        public static void AddMainServicesConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            bool useMicroServices = configuration.GetSection(AppSettings.WebApplicationSettings)
                                                 .GetSection(AppSettings.WebApplication_UseMicroServices).Get<bool>();
            if (useMicroServices)
            {
                services.MicroServices_AddUrlBackendSettingsServicesConfigurations(configuration);

                services.MicroServices_AddProvidersServicesConfigurations();
            }
            else
            {
                services.DirectBackendServices_ContentService_AddCommonHelpersServicesConfigurations(configuration);

                services.DirectBackendServices_ContentService_AddContentBLLServicesConfigurations();

                services.DirectBackendServices_ContentService_AddRepositoriesConfigurations(configuration);

                services.DirectBackendServices_ContentService_AddFluentValidationConfigurations();

                services.DirectBackendServices_AddFilesServicesConfigurationsConfigurations(configuration);

                services.DirectBackendServices_AddEmailServicesConfigurations(configuration);
            }
        }
    }
}

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using EmtEvents.Services.Configurations.AppSetting.Constants;

namespace EmtEvents.AppStartup.WebApplication.ApplicationServices
{
    public static class BusinessLogicServicesConfigurations
    {
        public static void AddBusinessLogicServicesConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            bool useMicroServices = configuration.GetSection(AppSettings.WebApplicationSettings)
                                                 .GetSection(AppSettings.WebApplication_UseMicroServices).Get<bool>();
            if (useMicroServices)
            {
                services._AddBusinessLogicMicroServicesConfigurations(configuration);
            }
            else
            {
                services._AddBusinessLogicDirectBackendServicesConfigurations();
            }
        }
    }
}

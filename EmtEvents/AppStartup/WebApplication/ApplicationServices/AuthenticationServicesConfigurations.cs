using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using EmtEvents.AppStartup.DirectBackendServices.IdentityService.ApplicationServices;
using EmtEvents.AppStartup.MicroServices.ApplicationServices;
using EmtEvents.Services.Configurations.AppSetting.Constants;

namespace EmtEvents.AppStartup.WebApplication.ApplicationServices
{
    public static class AuthenticationServicesConfigurations
    {
        public static void AddAuthenticationServicesConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            bool useMicroServices = configuration.GetSection(AppSettings.WebApplicationSettings)
                                                 .GetSection(AppSettings.WebApplication_UseMicroServices).Get<bool>();
            if (useMicroServices)
            {
                services.MicroServices_AddIdentityServerAuthentication(configuration);
            }
            else
            {
                services.IdentityService_DirectedBackendServicesConfigurations_ConfigureServices(configuration);
            }
        }
    }
}

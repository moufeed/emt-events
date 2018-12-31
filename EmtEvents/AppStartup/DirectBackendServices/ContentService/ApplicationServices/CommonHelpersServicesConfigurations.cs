using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using EmtEvents.Services.Configurations.AppSetting.Constants;
using TamTechBackendSDK.Common.Services.Helpers;
using TamTechBackendSDK.ContentService.Services.Helpers.ExpressionValidations;
using TamTechBackendSDK.ContentService.Services.Helpers.ExpressionValidations.Settings;

namespace EmtEvents.AppStartup.DirectBackendServices.ContentService.ApplicationServices
{
    public static class CommonHelpersServicesConfigurations
    {
        public static void DirectBackendServices_ContentService_AddCommonHelpersServicesConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            // static class 
            services.AddSingleton<IHelperService, HelperService>();



            if (!services.Any(s => s.ServiceType == typeof(IExpressionValidationsService)))
            {
                services.AddTransient<IExpressionValidationsService, ExpressionValidationsService>((serviceExtension) =>
                {
                    var RegexExpressionsSettings = configuration.GetSection(AppSettings.DirectBackendSDKsSettings)
                                      .GetSection(AppSettings.DirectBackendSDK_ContentService_RegexExpressionsSettings).Get<RegexExpressionsSettings>();
                    return new ExpressionValidationsService(RegexExpressionsSettings);
                });
            }

        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using EmtEvents.Services.Configurations.AppSetting.Constants;
using TamTechBackendSDK.EmailService.Services;
using TamTechBackendSDK.EmailService.Settings;
using TamTechBackendSDK.Common.Services.ApplicationInsightsTelemetry;
using TamTechBackendSDK.Common.Services.ApplicationInsightsTelemetry.Settings;

namespace EmtEvents.AppStartup.DirectBackendServices.EmailService
{
    public static class EmailServicesConfigurations
    {
        public static void DirectBackendServices_AddEmailServicesConfigurations(this IServiceCollection services, IConfiguration Configuration)
        {

            if (!services.Any(s => s.ServiceType == typeof(ITelemetryClientService)))
            {
                services.AddTransient<ITelemetryClientService, TelemetryClientService>((serviceExtension) =>
                {
                    TelemetryClientSettings insightsSettings = Configuration.GetSection(AppSettings.WebApplicationSettings)
                                                                             .GetSection(AppSettings.WebApplication_ApplicationInsights)
                                                                             .Get<TelemetryClientSettings>();
                    IHttpContextAccessor httpContextAccessor = serviceExtension.GetRequiredService<IHttpContextAccessor>();
                    return new TelemetryClientService(httpContextAccessor, insightsSettings);
                });
            }

            services.AddTransient<IEmailSender, SendGridEmailSender>(
                (serviceExtension) =>
                {
                    ITelemetryClientService telemetry = serviceExtension.GetService<ITelemetryClientService>();
                    TamTechBackendSDK.EmailService.Settings.SendGridSettings settings = Configuration
                                                                                                .GetSection(AppSettings.DirectBackendSDKsSettings)
                                                                                                .GetSection(AppSettings.DirectBackendSDK_EmailService_SendGrid)
                                                                                                .Get<TamTechBackendSDK.EmailService.Settings.SendGridSettings>();
                    SendGridEmailSender sender = new SendGridEmailSender(telemetry, settings.ApiKey);

                    return sender;
                }

                );






        }
    }
}

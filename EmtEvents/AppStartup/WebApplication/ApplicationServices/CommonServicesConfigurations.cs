using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using EmtEvents.Services.Configurations.AppSetting;
using EmtEvents.Services.Configurations.AppSetting.Constants;
using TamTechSDK.Common.Helpers.Converters;
using TamTechSDK.Common.Services.ContentService.Menus;
using TamTechSDK.Common.Services.Helpers;
using TamTechSDK.Common.Services.Upload;
using TamTechSDK.Common.Services.Upload.FileTypes;
using TamTechSDK.Web.Services.Configurations.AppSetting;
using TamTechSDK.Web.Services.Configurations.Cultures;
using TamTechSDK.Web.Services.ContentService.Menus.PublicService;
using TamTechSDK.Web.Services.Telemetry;
using TamTechSDK.Web.Services.Telemetry.Settings;
using TamTechSDK.Web.Services.Validations;

namespace EmtEvents.AppStartup.WebApplication.ApplicationServices
{
    public static class CommonServicesConfigurations
    {
        public static void AddCommonServicesConfigurations(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddApplicationInsightsTelemetryConfigurations(configuration);

            services.AddScoped<IWebApplicationSettingsService, WebApplicationSettingsService>();

            services.AddSingleton<IHelperService, HelperService>();
            services.AddScoped<IStringConverters, StringConverters>();
            services.AddScoped<IExpressionValidation, ExpressionValidation>();


            // services.AddScoped<ICulturesManager, ConstantsCulturesService>();   




            services.AddScoped<IUploadManagerService, UploadManagerService>((serviceExtension) =>
            {
                List<FileTypesSettingsModel> Settings = configuration.GetSection(AppSettings.WebApplicationSettings)
                                                                     .GetSection(AppSettings.WebApplication_FilesTypesSettings)
                                                                     .GetSection(AppSettings.FilesTypes)
                                                                     .Get<List<FileTypesSettingsModel>>();
                var uploadService = serviceExtension.GetRequiredService<IUploadService>();
                return new UploadManagerService(Settings, uploadService);
            });



            bool CacheMenus = configuration.GetSection(AppSettings.WebApplicationSettings)
                             .GetSection(AppSettings.WebApplication_CacheMenus)
                             .Get<bool>();
            if (CacheMenus)
            {
                services.AddScoped<IPublicMenusService, WebPublicCashedMenusService>();
            }
            else
            {
                services.AddScoped<IPublicMenusService, WebPublicMenusService>();
            }
        }
    }
}

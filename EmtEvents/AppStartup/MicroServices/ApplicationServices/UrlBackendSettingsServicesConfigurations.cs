using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using EmtEvents.Services.Configurations.AppSetting.Constants;
using TamTechSDK.Common.Services.ContentService;
using TamTechSDK.Common.Services.ContentService.Brands.Settings;
using TamTechSDK.Common.Services.ContentService.Categories.Settings;
using TamTechSDK.Common.Services.ContentService.Menus.Settings;
using TamTechSDK.Common.Services.ContentService.Pages.Settings;
using TamTechSDK.Common.Services.ContentService.Products.Settings;
using TamTechSDK.Common.Services.Identity.Settings;
using TamTechSDK.Common.Services.Upload.FileTypes;
using TamTechSDK.Common.Services.Upload.Settings;

namespace EmtEvents.AppStartup.MicroServices.ApplicationServices
{
    public static class UrlBackendSettingsServicesConfigurations
    {
        public static void MicroServices_AddUrlBackendSettingsServicesConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUploadBackendSettings, UploadBackendSettings>((serviceExtension) =>
            {
                var url = configuration
                .GetSection(AppSettings.MicroServicesSettings)
                .GetSection(AppSettings.MicroServices_UploadService)
                .GetValue<string>("Url");

                return new UploadBackendSettings(url);
            });


            services.AddScoped<IIdentityBackendSettings, IdentityBackendSettings>((serviceExtension) =>
            {
                var url = configuration
                .GetSection(AppSettings.MicroServicesSettings)
                .GetSection(AppSettings.MicroServices_IdentityService)
                .GetValue<string>("Url");

                return new IdentityBackendSettings(url);
            });

            services.AddScoped<IContentsServiceSettings, ContentsServiceSettings>((serviceExtension) =>
            {
                var url = configuration
                .GetSection(AppSettings.MicroServicesSettings)
                .GetSection(AppSettings.MicroServices_ContentsService)
                .GetValue<string>("Url");

                return new ContentsServiceSettings(url);
            });




            services.AddScoped<IPageServiceSettings, PageServiceSettings>();
            services.AddScoped<IProductManagerServiceSettings, ProductManagerServiceSettings>();
            services.AddScoped<IProductServiceSettings, ProductServiceSettings>();
            services.AddScoped<IBrandServiceSettings, BrandServiceSettings>();
            services.AddScoped<ICategoryServiceSettings, CategoryServiceSettings>();
            services.AddScoped<IMenusServicesSettings, MenusServicesSettings>();




        }
    }
}

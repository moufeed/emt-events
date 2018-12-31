using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using EmtEvents.Services.Configurations.AppSetting.Constants;
using TamTechBackendSDK.ContentService.Services.Sections;
using TamTechSDK.Common.Services.ContentService;
using TamTechSDK.Common.Services.ContentService.Brands;
using TamTechSDK.Common.Services.ContentService.Categories;
using TamTechSDK.Common.Services.ContentService.Galleries;
using TamTechSDK.Common.Services.ContentService.Menus;
using TamTechSDK.Common.Services.ContentService.Pages;
using TamTechSDK.Common.Services.ContentService.Posts;
using TamTechSDK.Common.Services.ContentService.Products;
using TamTechSDK.Common.Services.ContentService.Reviews;
using TamTechSDK.Common.Services.ContentService.Services;
using TamTechSDK.Common.Services.ContentService.Sliders;
using TamTechSDK.Common.Services.Email;
using TamTechSDK.Common.Services.Identity;
using TamTechSDK.Common.Services.ServiceBus;
using TamTechSDK.Common.Services.SMS;
using TamTechSDK.Common.Services.Upload;

namespace EmtEvents.AppStartup.WebApplication.ApplicationServices
{
    public static class BLLMicroServicesConfigurations
    {
        public static void _AddBusinessLogicMicroServicesConfigurations(this IServiceCollection services, IConfiguration configuration)
        {

            #region Contents Service

            services.AddScoped<IMenusServices, MenusServices>();
            services.AddTransient<ICategoriesServices, CategoriesServices>();
            services.AddTransient<IProductsManagerService, ProductsManagerService>();
            services.AddTransient<IProductsService, ProductsService>();
            services.AddTransient<IBrandsServices, BrandsServices>();
            services.AddTransient<IPageService, PageService>();
            services.AddTransient<IReviewsServices, ReviewsServices>();
            // services.AddTransient<IServicesService, ServicesService>();
            services.AddTransient<IContentServices, ContentServices>();
            services.AddTransient<IGalleriesService, GalleriesService>();
            services.AddTransient<IPostsService, PostsService>();


            #endregion

            #region Identity Service 

            services.AddTransient<IUsersManagerService, UsersManagerService>();
            services.AddTransient<IRolesService, RolesService>();

            #endregion


            #region Upload Service 

            services.AddTransient<IUploadService, AzureBlobUploadService>();

            #endregion


            #region Service Bus 

            services.AddTransient<IServiceBus, ServiceBusProvider>();

            #endregion

            #region Email Service  

            services.AddTransient<IEmailSenderService, EmailSenderToServiceBus>((serviceExtension) =>
            {
                IServiceBus bus = serviceExtension.GetRequiredService<IServiceBus>();
                ServiceBusSettings settings = configuration.GetSection(AppSettings.MicroServicesSettings)
                                                           .GetSection(AppSettings.MicroServices_EmailService)
                                                           .Get<ServiceBusSettings>();
                return new EmailSenderToServiceBus(settings, bus);
            });

            #endregion


            #region SMS Service 

            services.AddTransient<ISMSService, SMSServiceBus>((serviceExtension) =>
            {
                IServiceBus bus = serviceExtension.GetRequiredService<IServiceBus>();
                ServiceBusSettings settings = configuration.GetSection(AppSettings.MicroServicesSettings)
                                                                .GetSection(AppSettings.MicroServices_SMSService)
                                                                .Get<ServiceBusSettings>();
                return new SMSServiceBus(settings, bus);
            });

            #endregion
        }
    }
}

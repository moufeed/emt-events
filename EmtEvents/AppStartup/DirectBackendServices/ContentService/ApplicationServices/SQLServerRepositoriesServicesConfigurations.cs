using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TamTech.Common.Models.Settings;
using EmtEvents.Services.Configurations.AppSetting.Constants;
using TamTechBackendSDK.ContentService.Repositories;
using TamTechBackendSDK.ContentService.Repositories.CosmosRepositories;
using TamTechBackendSDK.ContentService.Repositories.IRepositories;
using TamTechBackendSDK.ContentService.SQL;
using TamTechBackendSDK.ContentService.SQL.Repositories;

namespace EmtEvents.AppStartup.DirectBackendServices.ContentService.ApplicationServices
{

    public static class EFCoreRepositoriesServicesConfigurations
    {
        public static void ContentService_AddEFCoreRepositoriesConfigurations(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<ContentDbContext>(options =>
                        options.UseSqlServer(configuration.GetConnectionString(AppSettings.DirectBackendSDK_ContentService_ContentDB)));

            services.AddTransient<IContentUtilitiesRepository, EFCoreContentUtilitiesRepository>();
            services.AddTransient(typeof(IRepository<>), typeof(EFCoreDBRepository<>));
            services.AddTransient<IProductRepository, EFCoreProductRepository>();
            services.AddTransient<ICategoryRepository, EFCoreCategoryRepository>();
            services.AddTransient<IBrandRepository, EFCoreBrandRepository>();
            services.AddTransient<IPageRepository, EFCorePageRepository>();
            services.AddTransient<IMenuRepository, EFCoreMenuRepository>();
            services.AddTransient<ISliderRepository, EFCoreSliderRepository>();
            services.AddTransient<IServiceRepository, EFCoreServiceRepository>();
            services.AddTransient<IGalleryRepository, EFCoreGalleryRepository>();

            services.AddTransient<ISectionRepository, EFCoreSectionRepository>();
            services.AddTransient<IPostRepository, EFCorePostRepository>();

            services.AddTransient<IRequestRepository, EFCoreRequestRepository>();
            services.AddTransient<ICityRepository, EFCoreCityRepository>();
            services.AddTransient<IStatusRepository, EFCoreStatusRepository>();
        }

    }
}

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TamTech.MockServices.Content;
using TamTech.MockServices.Pages;
using EmtEvents.Services.Configurations.AppSetting.Constants;
using TamTechBackendSDK.ContentService.Repositories;

namespace EmtEvents.AppStartup.DirectBackendServices.ContentService.ApplicationServices
{

    public static class MockRepositoriesServicesConfigurations
    {
        public static void _ContentService_AddMockRepositoriesConfigurations(this IServiceCollection services, IConfiguration configuration)
        {

            //var useMock = configuration.GetValue<bool>("ContentService_UseMockServices");

            //if (useMock)
            //{
            //    services.AddSingleton<IPagesRepository, MockPagesRepository>();
            //    services.AddSingleton<IProductsRepository, MockProductsRepository>();
            //    services.AddSingleton<IContentsRepository, MockContentRepository>();
            //}
        }

    }
}

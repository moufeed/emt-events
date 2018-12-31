using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using TamTechSDK.Common.Providers.Requests;

namespace EmtEvents.AppStartup.MicroServices.ApplicationServices
{
    public static class ProvidersServicesConfigurations
    {
        public static void MicroServices_AddProvidersServicesConfigurations(this IServiceCollection services)
        {
            services.AddScoped<IRequestProvider, RequestProvider>((serviceExtension) =>
            {
                IHttpContextAccessor httpContextAccessor = serviceExtension.GetRequiredService<IHttpContextAccessor>();
                // var _token = Task.Run(async () => await httpContextAccessor.HttpContext.GetTokenAsync("access_token")).Result;
                // var token = GetToken(httpContextAccessor.HttpContext).GetAwaiter().GetResult();
                string token = GetToken(httpContextAccessor.HttpContext).Result;
                return new RequestProvider(token);
            });

            async Task<string> GetToken(HttpContext httpContext)
            {
                return await httpContext.GetTokenAsync("access_token");
            }
        }
    }
}

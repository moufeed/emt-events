using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using EmtEvents.Services.Configurations.AppSetting.Constants;
using TamTechSDK.Common.Services.Identity.Models;

namespace EmtEvents.AppStartup.MicroServices.ApplicationServices
{

    public static class AuthenticationServicesConfigurations
    {
        public static void MicroServices_AddIdentityServerAuthentication(this IServiceCollection services, IConfiguration Configuration)
        {


            IdentityServiceSettings identityServiceSettings = Configuration
                                                                      .GetSection(AppSettings.MicroServicesSettings)
                                                                      .GetSection(AppSettings.MicroServices_IdentityService)
                                                                      .Get<IdentityServiceSettings>();

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = identityServiceSettings.DefaultScheme;
                options.DefaultChallengeScheme = identityServiceSettings.DefaultChallengeScheme;
            })
            .AddCookie(identityServiceSettings.CookieAuthenticationScheme)
            .AddOpenIdConnect(identityServiceSettings.OpenIdConnectAuthenticationScheme, options =>
            {
                options.SignInScheme = identityServiceSettings.SignInScheme;
                options.Authority = identityServiceSettings.Url;
                options.RequireHttpsMetadata = identityServiceSettings.RequireHttpsMetadata;
                options.ClientId = identityServiceSettings.ClientId;
                options.ClientSecret = identityServiceSettings.ClientSecrets;
                options.ResponseType = identityServiceSettings.ResponseType;
                options.SaveTokens = identityServiceSettings.SaveTokens;
                options.GetClaimsFromUserInfoEndpoint = identityServiceSettings.GetClaimsFromUserInfoEndpoint;
                foreach (string scop in identityServiceSettings.Scops)
                {
                    options.Scope.Add(scop);
                }
            });

        }
    }
}

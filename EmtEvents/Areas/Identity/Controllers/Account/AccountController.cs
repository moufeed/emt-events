using IdentityModel;
using IdentityServer4.Services;
using IdentityServer4.Stores;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using IdentityServer4.Events;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Identity;
using System.Web;
using Microsoft.Extensions.Configuration;
using TamTechBackendSDK.IdentityService.Models;
using TamTechBackendSDK.IdentityService.Services;
using TamTechSDK.Web.Filters;

namespace EmtEvents.Areas.Identity.Controllers
{
    [Area("Identity")]
    [ServiceFilter(typeof(AdminFilter))]
    public class AccountController : IdentityServer4.Quickstart.UI.AccountController
    {
        public AccountController(IIdentityServerInteractionService interaction,
                                 IClientStore clientStore,
                                 IAuthenticationSchemeProvider schemeProvider,
                                 IEventService events,
                                 UserManager<ApplicationUser> userManager,
                                 SignInManager<ApplicationUser> signInManager,
                                 IConfiguration configuration,
                                 IUserManagerService userManagerService,
                                 TamTechBackendSDK.IdentityService.Services.Configurations.AppSettings.IWebApplicationSettingsService IdentityServiceAppSettings)
            : base(interaction, clientStore, schemeProvider, events, userManager, signInManager, configuration, userManagerService, IdentityServiceAppSettings)
        {
        }


        /// <summary>
        /// TODO: move it to the Identity SDK to have default implementation
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        public IActionResult AccessDenied(string returnUrl = "")
        {
            return View();
        }
    }
}
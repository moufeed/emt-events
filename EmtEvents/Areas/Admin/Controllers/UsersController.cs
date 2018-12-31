using TamTechSDK.Common.Services.Identity;
using TamTechSDK.Common.Services.Identity.Settings;
using TamTechSDK.Web.Services.Telemetry;
using TamTechSDK.Web.Controllers.Admin;
using TamTechSDK.Web.Services.Configurations.Cultures;
using Microsoft.Extensions.Localization;
namespace EmtEvents.Areas.Admin.Controllers
{
    public class UsersController : UsersBaseController
    {
        #region Ctors
        public UsersController(ITelemetryClientService telemetryClientService,
                               IUsersManagerService identityService,
                               IRolesService rolesService,
                                  IStringLocalizer<AdminBaseController> localizer
                              )
               : base(telemetryClientService, identityService, rolesService, localizer)
        {
        }
        #endregion  

    }
}
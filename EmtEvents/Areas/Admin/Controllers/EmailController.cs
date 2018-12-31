
using Microsoft.Extensions.Localization;
using TamTechSDK.Common.Services.Email;
using TamTechSDK.Common.Services.Identity;
using TamTechSDK.Web.Controllers.Admin;
using TamTechSDK.Web.Services.Configurations.Cultures;
using TamTechSDK.Web.Services.Telemetry;

namespace EmtEvents.Areas.Admin.Controllers
{
    public class EmailController : EmailBaseController
    {
        public EmailController(
                                IUsersManagerService IdentityService,
                                IEmailSenderService emailService,
                                ITelemetryClientService telemetryClientService,
                                IStringLocalizer<AdminBaseController> localizer)
            : base(IdentityService, emailService, telemetryClientService, localizer)
        {

        }

    }
}
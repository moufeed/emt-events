using Microsoft.Extensions.Localization;
using TamTechSDK.Common.Services.Identity;
using TamTechSDK.Common.Services.ServiceBus;
using TamTechSDK.Common.Services.SMS;
using TamTechSDK.Web.Controllers.Admin;
using TamTechSDK.Web.Services.Configurations.Cultures;
using TamTechSDK.Web.Services.Telemetry;

namespace EmtEvents.Areas.Admin.Controllers
{
    public class SmsController : SmsBaseController
    {
        public SmsController(ITelemetryClientService telemetryClientService,
            ISMSService sMSService, IUsersManagerService IdentityService,
            ServiceBusSettings serviceBusSettings,
            IStringLocalizer<AdminBaseController> _localizer) : base(telemetryClientService, sMSService, IdentityService, serviceBusSettings, _localizer)
        {
        }
    }
}
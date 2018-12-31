using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using TamTechSDK.Common.Services.ContentService;
using TamTechSDK.Common.Services.Identity;
using TamTechSDK.Common.Services.SMS;
using TamTechSDK.Common.Services.Upload;
using TamTechSDK.Web.Controllers.Admin;
using TamTechSDK.Web.Services.Configurations.AppSetting;
using TamTechSDK.Web.Services.Configurations.Cultures;
using TamTechSDK.Web.Services.Telemetry;

namespace EmtEvents.Areas.Admin.Controllers
{
    public class HomeController : HomeBaseController
    {
        public HomeController(ITelemetryClientService telemetryClientService,
            IWebApplicationSettingsService webApplicationSettingsService,
            IUploadManagerService uploadManager,
            IStringLocalizer<AdminBaseController> localizer,
            IContentServices contentServices)
            : base(telemetryClientService, webApplicationSettingsService, uploadManager, localizer, contentServices)
        {
        }
    }
}

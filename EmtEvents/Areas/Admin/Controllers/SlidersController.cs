using TamTechSDK.Web.Controllers.Admin;
using TamTechSDK.Web.Services.Telemetry;
using TamTechSDK.Common.Services.Upload;
using TamTechSDK.Common.Services.ContentService.Sliders;
using TamTechSDK.Web.Services.Configurations.Cultures;
using Microsoft.Extensions.Localization;

namespace EmtEvents.Areas.Admin.Controllers
{
    public class SlidersController : SlidersBaseController
    {
        public SlidersController(ITelemetryClientService telemetryClientService, ISlidersServices sliderService,
            IUploadManagerService uploadManager, IStringLocalizer<AdminBaseController> _localizer)
            : base(telemetryClientService, sliderService, uploadManager, _localizer)
        {

        }
    }
}

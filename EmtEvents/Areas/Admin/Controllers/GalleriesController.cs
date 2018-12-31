using TamTechSDK.Common.Services.ContentService;
using TamTechSDK.Common.Services.ContentService.Galleries;
using TamTechSDK.Common.Services.ContentService.Reviews;
using TamTechSDK.Web.Controllers.Admin;
using TamTechSDK.Web.Services.Telemetry;
using TamTechSDK.Common.Services.Upload;
using TamTechSDK.Common.Services.Upload.Settings;
using TamTechSDK.Web.Services.Configurations.Cultures;
using Microsoft.Extensions.Localization;

namespace EmtEvents.Areas.Admin.Controllers
{
    public class GalleriesController : GalleryBaseController
    {
        public GalleriesController(ITelemetryClientService telemetryClientService,
            IGalleriesService galeriesService,
             IUploadManagerService uploadManager, IStringLocalizer<AdminBaseController> localizer)
            : base(telemetryClientService, galeriesService, uploadManager, localizer)
        {
        }
    }
}
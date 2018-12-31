using Microsoft.Extensions.Localization;
using TamTechSDK.Common.Helpers.Converters;
using TamTechSDK.Common.Services.ContentService.Pages;
using TamTechSDK.Common.Services.Upload;
using TamTechSDK.Web.Controllers.Admin;
using TamTechSDK.Web.Services.Configurations.Cultures;
using TamTechSDK.Web.Services.Telemetry;

namespace EmtEvents.Areas.Admin.Controllers
{
    public class PagesController : PagesBaseController
    {
        #region Ctors

        public PagesController(ITelemetryClientService telemetryClientService,
                         IPageService pageService,
                         IUploadManagerService uploadManager,
                         IStringConverters stringConverters,
                         IStringLocalizer<AdminBaseController> localizer)
          : base(telemetryClientService, pageService, uploadManager, stringConverters, localizer)
        { }

        #endregion
    }
}
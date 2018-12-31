using Microsoft.Extensions.Localization;
using TamTechSDK.Common.Services.ContentService.Brands;
using TamTechSDK.Common.Services.Upload;
using TamTechSDK.Web.Controllers.Admin;
using TamTechSDK.Web.Services.Configurations.Cultures;
using TamTechSDK.Web.Services.Telemetry;

namespace EmtEvents.Areas.Admin.Controllers
{
    public class ManufacturerController : ManufacturerBaseController
    {
        #region Ctors
        public ManufacturerController(ITelemetryClientService telemetryClientService,
                                        IBrandsServices brandService,
                                        IUploadService uploadService,
                                        IStringLocalizer<AdminBaseController> localizer)
            : base(telemetryClientService, brandService, uploadService, localizer)
        {
        }
        #endregion 
    }
}
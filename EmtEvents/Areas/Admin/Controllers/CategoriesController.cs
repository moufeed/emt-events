using TamTechSDK.Web.Controllers.Admin;
using TamTechSDK.Web.Services.Telemetry;
using TamTechSDK.Common.Services.ContentService.Categories;
using TamTechSDK.Common.Services.Upload;
using TamTechSDK.Web.Services.Configurations.Cultures;
using Microsoft.Extensions.Localization;

namespace EmtEvents.Areas.Admin.Controllers
{
    public class CategoriesController : CategoriesBaseController
    {

        #region Ctors
        public CategoriesController(
                                    ITelemetryClientService telemetryClientService,
                                    ICategoriesServices categoryService,
                                    IUploadService uploadService,
              IStringLocalizer<AdminBaseController> localizer)
            : base(telemetryClientService, categoryService, uploadService, localizer)
        {

        }
        #endregion

    }
}

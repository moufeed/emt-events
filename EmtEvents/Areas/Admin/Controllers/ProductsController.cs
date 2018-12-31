using Microsoft.Extensions.Localization;
using TamTechSDK.Common.Services.ContentService;
using TamTechSDK.Common.Services.ContentService.Brands;
using TamTechSDK.Common.Services.ContentService.Categories;
using TamTechSDK.Common.Services.ContentService.Products;
using TamTechSDK.Common.Services.Upload;
using TamTechSDK.Common.Services.Upload.FileTypes;
using TamTechSDK.Common.Services.Upload.Settings;
using TamTechSDK.Web.Controllers.Admin;
using TamTechSDK.Web.Services.Configurations.Cultures;
using TamTechSDK.Web.Services.Telemetry;

namespace EmtEvents.Areas.Admin.Controllers
{
    public class ProductsController : ProductsBaseController
    {
        #region Ctors
        public ProductsController(
                                    ITelemetryClientService telemetryClientService,
                                    IProductsManagerService productsManagerService,
                                    IBrandsServices brandsService,
                                    ICategoriesServices categoriesService,
                                    IContentServices contentService,
                                    IUploadManagerService uploadManager,
                                    IStringLocalizer<AdminBaseController> localizer
                                    )
            : base(telemetryClientService, productsManagerService, brandsService, categoriesService, contentService, uploadManager, localizer)
        {
        }
        #endregion  
    }
}



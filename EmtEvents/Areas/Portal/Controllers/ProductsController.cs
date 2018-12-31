using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using TamTechSDK.Common.Services.ContentService.Menus;
using TamTechSDK.Common.Services.ContentService.Products;
using TamTechSDK.Web;
using TamTechSDK.Web.Controllers.Portal;
using TamTechSDK.Web.Services.Telemetry;

namespace EmtEvents.Areas.Portal.Controllers
{

    public class ProductsController : ProductsBaseController
    {
        public ProductsController(ITelemetryClientService telemetryClientService, IProductsService productsService, IMenusServices menusServices)
            : base(telemetryClientService, menusServices, productsService)
        {
        }
    }
}
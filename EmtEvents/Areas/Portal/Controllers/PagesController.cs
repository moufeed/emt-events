using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using TamTechSDK.Common.Services.ContentService.Menus;
using TamTechSDK.Common.Services.ContentService.Pages;
using TamTechSDK.Web;
using TamTechSDK.Web.Controllers.Portal;
using TamTechSDK.Web.Services.Telemetry;

namespace EmtEvents.Areas.Portal.Controllers
{
    public class PagesController : PagesBaseController
    {
        public PagesController(ITelemetryClientService telemetryClientService, IPageService pageService, IMenusServices menusServices)
            : base(telemetryClientService, pageService, menusServices)
        {
        }
    }
}
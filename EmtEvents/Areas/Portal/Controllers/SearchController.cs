using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using TamTechSDK.Common.Services.ContentService.Menus;
using TamTechSDK.Web;
using TamTechSDK.Web.Controllers.Portal;
using TamTechSDK.Web.Services.Telemetry;

namespace EmtEvents.Areas.Portal.Controllers
{

    public class SearchController : SearchBaseController
    {
        public SearchController(ITelemetryClientService telemetryClientService, IMenusServices menusServices)
            : base(telemetryClientService, menusServices)
        {
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TamTechSDK.Common.Services.ContentService.Menus;
using TamTechSDK.Common.Services.ContentService.Galleries;
using TamTechSDK.Web.Controllers.Portal;
using TamTechSDK.Web.Services.Telemetry;
using Microsoft.Extensions.Localization;
using TamTechSDK.Web;

namespace EmtEvents.Areas.Portal.Controllers
{
    
    public class GalleriesController : GalleriesBaseController
    {
        public GalleriesController(ITelemetryClientService telemetryClientService,
            IMenusServices menusServices, IGalleriesService galleriesService)
            : base(telemetryClientService, menusServices, galleriesService)
        {
        }

    }

     
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using TamTechSDK.Common.Services.ContentService.Services;
using TamTechSDK.Common.Services.ContentService.Menus;
using TamTechSDK.Web;
using TamTechSDK.Web.Controllers.Portal;
using TamTechSDK.Web.Services.Telemetry;

namespace EmtEvents.Areas.Portal.Controllers
{
    public class ServicesController : ServicesBaseController
    {
        public ServicesController(ITelemetryClientService telemetryClientService, IMenusServices menusServices,
              IServicesService servicesservice)
            : base(telemetryClientService, menusServices, servicesservice,true)
        {
        }
    }
}
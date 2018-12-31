using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamTechSDK.Common.Services.ContentService.City;
using TamTechSDK.Common.Services.ContentService.Request;
using TamTechSDK.Common.Services.ContentService.Status;
using TamTechSDK.Web.Controllers.Admin;
using TamTechSDK.Web.Services.Telemetry;

namespace EmtEvents.Areas.Admin.Controllers
{
    public class RequestController : RequestBaseController
    {
        public RequestController(ITelemetryClientService telemetryClientService, IRequestService requestService,
            IStringLocalizer<AdminBaseController> localizer,
            ICityService cityService,
            IStatusService statusService) : base(telemetryClientService, requestService, localizer, cityService, statusService)
        {
        }
    }
}

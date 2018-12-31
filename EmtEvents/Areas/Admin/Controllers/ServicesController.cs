

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamTechSDK.Common.Services.ContentService.Services;
using TamTechSDK.Common.Services.Upload;
using TamTechSDK.Web.Controllers.Admin;
using TamTechSDK.Web.Services.Configurations.Cultures;
using TamTechSDK.Web.Services.Telemetry;
using Microsoft.Extensions.Localization;
namespace EmtEvents.Areas.Admin.Controllers
{
    public class ServicesController : ServicesBaseController
    {
        public ServicesController(
                                    ITelemetryClientService telemetryClientService,
                                    IServicesService servicesService,
                                    IUploadManagerService UploadManager,
                                    IStringLocalizer<AdminBaseController> localizer) : base(telemetryClientService,
                                                                                servicesService,
                                                                                UploadManager,
                                                                                localizer)
        {
        }
    }
}

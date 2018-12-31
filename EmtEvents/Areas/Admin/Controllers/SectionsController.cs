using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using TamTechSDK.Common.Services.ContentService.Sections;
using TamTechSDK.Common.Services.Upload;
using TamTechSDK.Web.Controllers.Admin;
using TamTechSDK.Web.Services.Configurations.Cultures;
using TamTechSDK.Web.Services.Telemetry;

namespace EmtEvents.Areas.Admin.Controllers
{
    public class SectionsController : SectionsBaseController
    {
        public SectionsController(ITelemetryClientService telemetryClientService,
                                    ISectionsService sectionsService,
                                    IUploadManagerService uploadManager,
                                    IStringLocalizer<AdminBaseController> localizer)
            : base(
                    telemetryClientService,
                    sectionsService,
                    uploadManager,
                    localizer)
        { }


    }
}

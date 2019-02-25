using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Localization;
using TamTechSDK.Common.Services.ContentService.Testimonials;
using TamTechSDK.Common.Services.Upload;
using TamTechSDK.Web.Controllers.Admin;
using TamTechSDK.Web.Services.Telemetry;

namespace EmtEvents.Areas.Admin.Controllers
{
    public class TestimonialsController : TestimonialsBaseController
    {
        public TestimonialsController(
            ITelemetryClientService telemetryClientService, 
            IStringLocalizer<AdminBaseController> localizer,
            ITestimonialsServices testimonialservices,
            IUploadManagerService uploadManager
            ) : base(telemetryClientService, localizer, testimonialservices, uploadManager)
        {
        }
    }
}

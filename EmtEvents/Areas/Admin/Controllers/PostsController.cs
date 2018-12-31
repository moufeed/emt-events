using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using TamTechSDK.Common.Helpers.Converters;
using TamTechSDK.Common.Services.ContentService.Posts;
using TamTechSDK.Common.Services.ContentService.Sections;
using TamTechSDK.Common.Services.Upload;
using TamTechSDK.Web.Controllers.Admin;
using TamTechSDK.Web.Services.Configurations.Cultures;
using TamTechSDK.Web.Services.Telemetry;

namespace EmtEvents.Areas.Admin.Controllers
{
    public class PostsController : PostsBaseController
    {
        public PostsController(
            ITelemetryClientService telemetryClientService,
            IPostsService postservice,
            IStringLocalizer<AdminBaseController> localizer,
            IUploadManagerService uploadManager,
            ISectionsService sectionsService,
            IStringConverters stringConverters)
                                            : base(telemetryClientService,
                                                    postservice, localizer,
                                                    uploadManager, sectionsService, stringConverters)
        {
        }
    }
}
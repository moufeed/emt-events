using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using TamTechSDK.Common.Services.ContentService.Menus;
using TamTechSDK.Common.Services.ContentService.Posts;
using TamTechSDK.Common.Services.ContentService.Sections;
using TamTechSDK.Common.Services.Upload;
using TamTechSDK.Web;
using TamTechSDK.Web.Controllers.Portal;
using TamTechSDK.Web.Services.Telemetry;

namespace EmtEvents.Areas.Portal.Controllers
{
    public class PostsController : PostsBaseController
    {
        public PostsController(ITelemetryClientService telemetryClientService,
            IMenusServices menusServices,
            IPostsService postservice, ISectionsService SectionsService)
            : base(telemetryClientService, menusServices, postservice, SectionsService)
        {
        }
    }
}
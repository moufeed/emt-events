using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using TamTechSDK.Common.Services.ContentService.Menus;
using TamTechSDK.Common.Services.ContentService.Menus.Models;
using TamTechSDK.Web.Controllers.Admin;
using TamTechSDK.Web.Services.Configurations.AppSetting;
using TamTechSDK.Web.Services.Configurations.Cultures;
using TamTechSDK.Web.Services.Telemetry;
namespace EmtEvents.Areas.Admin.Controllers
{
    public class MenusController : MenusBaseController
    {

        public MenusController(ITelemetryClientService telemetryClientService, IMenusServices MenusServices,
       IWebApplicationSettingsService appSettingsService, IStringLocalizer<AdminBaseController> localizer)
            : base(telemetryClientService, MenusServices, appSettingsService, localizer, 0)
        {

        }


    }
}
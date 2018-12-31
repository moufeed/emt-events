using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TamTechBackendSDK.EmailService.Services;
using TamTechSDK.Common.Models.ContactUs;
using TamTechSDK.Common.Services.ContentService.City;
using TamTechSDK.Common.Services.ContentService.Menus;
using TamTechSDK.Common.Services.ContentService.Pages;
using TamTechSDK.Common.Services.ContentService.Request;
using TamTechSDK.Common.Services.ContentService.Services;
using TamTechSDK.Common.Services.ContentService.Sliders;

using TamTechSDK.Common.Services.Email;
using TamTechSDK.Web;
using TamTechSDK.Web.Controllers.Portal;
using TamTechSDK.Web.Services.Configurations.AppSetting;
using TamTechSDK.Web.Services.Telemetry;

namespace EmtEvents.Areas.Portal.Controllers
{

    public class HomeController : HomeBaseController
    {
        public HomeController(ITelemetryClientService telemetryClientService,
                               IPageService pageService,
                               IMenusServices menusServices,
                               IConfiguration configuration,
                               IEmailSenderService emailSender, IWebApplicationSettingsService appSettingsService, IServicesService servicesservice,
                               ISlidersServices sliderService,
                               IRequestService requestService,
                               ICityService cityService)
                               : base(telemetryClientService, pageService,
                                        menusServices, configuration, emailSender, appSettingsService,
                                        servicesservice, sliderService, requestService, cityService)

        {

        }
    }
}
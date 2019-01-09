using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TamTechBackendSDK.EmailService.Services;
using TamTechSDK.Common.Models.ContactUs;
using TamTechSDK.Common.Models.Pagination;
using TamTechSDK.Common.Services.ContentService.City;
using TamTechSDK.Common.Services.ContentService.Menus;
using TamTechSDK.Common.Services.ContentService.Pages;
using TamTechSDK.Common.Services.ContentService.Posts;
using TamTechSDK.Common.Services.ContentService.Posts.Models;
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
        private IPostsService _postservice;
        private ISlidersServices _sliderService;
        private IWebApplicationSettingsService _appSettingsService;

        public HomeController(ITelemetryClientService telemetryClientService,
                               IPageService pageService,
                               IMenusServices menusServices,
                               IConfiguration configuration,
                               IEmailSenderService emailSender, IWebApplicationSettingsService appSettingsService, IServicesService servicesservice,
                               ISlidersServices sliderService,
                               IRequestService requestService,
                               ICityService cityService,
                              IPostsService postservice
                                
                             )
                               : base(telemetryClientService, pageService,
                                        menusServices, configuration, emailSender, appSettingsService,
                                        servicesservice, sliderService, requestService, cityService)

        {
            _postservice = postservice;
            _sliderService = sliderService;

            _appSettingsService = appSettingsService;
        }

        public override async Task<IActionResult> Index()
        {
            try
            {
                PaginationModel Pagination = new PaginationModel
                {
                    PageNumber = "1",
                    PageSize = 5
                };
                var latestPosts = await _postservice.GetPublicLatestPostsAsync(Pagination);
                ViewBag.Posts = latestPosts.Data != null ? latestPosts.Data : new List<PostDto>();
              
            }
            catch (Exception ex)
            {
                TrackException(ex);
            }
            return await base.Index();
        }

        public override async Task<IActionResult> AboutUs()
        {
            try
            {
                var publicClientsSlider = await _sliderService.GetPublicByKeyAsync(_appSettingsService.GetHomePageCarouselSliderKey());
                if (publicClientsSlider.Success)
                {
                    ViewBag.publicClientsSlider = publicClientsSlider.Data;
                }
            }
            catch (Exception ex)
            {
                TrackException(ex);
            }

            return await base.AboutUs();
        }
    }
}
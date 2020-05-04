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
using TamTechSDK.Common.Services.ContentService.Galleries;
using TamTechSDK.Common.Services.ContentService.Menus;
using TamTechSDK.Common.Services.ContentService.Pages;
using TamTechSDK.Common.Services.ContentService.Posts;
using TamTechSDK.Common.Services.ContentService.Posts.Models;
using TamTechSDK.Common.Services.ContentService.Request;
using TamTechSDK.Common.Services.ContentService.Services;
using TamTechSDK.Common.Services.ContentService.Sliders;
using TamTechSDK.Common.Services.ContentService.Testimonials;
using TamTechSDK.Common.Services.Email;
using TamTechSDK.Common.Services.Email.Models;
using TamTechSDK.Common.Services.Upload;
using TamTechSDK.Web;
using TamTechSDK.Web.Controllers.Portal;
using TamTechSDK.Web.Services.Configurations.AppSetting;
using TamTechSDK.Web.Services.Telemetry;

namespace EmtEvents.Areas.Portal.Controllers
{
    public class HomeController : HomeBaseController
    {
        private readonly IPageService _pageService;
        private readonly IWebApplicationSettingsService _appSettingsService;
        private readonly ISlidersServices _sliderService;
        private readonly IGalleriesService _GalleriesService;
        private readonly IPostsService _postservice;
        private readonly IServicesService _servicesservice;
        private readonly ITestimonialsServices _TestimonialsServices;
        private readonly IEmailSenderService _emailSender;


        public HomeController(ITelemetryClientService telemetryClientService,
                               IPageService pageService,
                               IMenusServices menusServices,
                               IConfiguration configuration,
                               IEmailSenderService emailSender, IWebApplicationSettingsService appSettingsService, IServicesService servicesservice,
                               ISlidersServices sliderService,
                               IRequestService requestService,
                               ICityService cityService,
                               IGalleriesService GalleriesService,
                               IPostsService postservice,
                               ITestimonialsServices testimonialservices,
                               IStringLocalizer<PublicBaseController> localizer,
                               IUploadManagerService uploadManager,
                               ITestimonialsServices TestimonialsServices)
                               : base(telemetryClientService, pageService,
                                        menusServices, configuration, emailSender, appSettingsService,
                                        servicesservice, sliderService, requestService, cityService, testimonialservices, uploadManager, localizer)

        {

            _TestimonialsServices = TestimonialsServices;
            _pageService = pageService;
            _appSettingsService = appSettingsService;
            _GalleriesService = GalleriesService;
            _sliderService = sliderService;
            _postservice = postservice;
            _servicesservice = servicesservice;
            _emailSender = emailSender;

        }

        public override async Task<IActionResult> Index()
        {

            try
            {
                var testimonial = await _TestimonialsServices.GetPublicListAsync(true);
                if (testimonial.Success)
                {
                    ViewBag.testimonials = testimonial.Data;
                }

                var publicMainSlider = await _sliderService.GetPublicByKeyAsync(_appSettingsService.GetHomePageMainSliderKey());
                if (publicMainSlider.Success)
                {
                    ViewBag.publicMainSlider = publicMainSlider.Data;
                }

               ViewBag.Posts = await _postservice.GetPublicListAsync(4);

                ViewBag.galleries = await _GalleriesService.GetPublicListAsync(4);

                var aboutSummary = await _pageService.GetPublicPageSummaryByIdAsync(_appSettingsService.GetHomePageSummuryId());

                if (aboutSummary.Success)
                {
                    ViewBag.aboutSummary = aboutSummary.Data;
                }

                var services = await _servicesservice.GetPublicListAsync(25,true);

                if (services.Success)
                {
                    ViewBag.services = services.Data;
                }

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

        
        [HttpPost]
        public async Task<IActionResult> ContactEmt(ContactUs model)
        {


           // ContactUs model = new ContactUs();
            try
            {
                if (ModelState.IsValid)
                {
                    var emailSettings = _appSettingsService.GetEmailSettings();
                    bool result = await _emailSender.SendAsync(new EmailModel
                    {
                        Email = emailSettings.From,
                        Subject = "Contact Us",
                        Message = $"Message from Email : {model.Email} - Mobile :{model.Mobile} - Message content is : {model.Message}",
                        ReasonOfSend = "ContactUs"

                    });
                    if (result)
                    {
                        TempData["UserName"] = model.Name;
                        return RedirectToAction("success");
                    }
                }
            }
            catch (Exception exc)
            {
                TrackException(exc);
            }
                ViewBag.Host = _appSettingsService.GetURl();
                return View("ContactUs");
        }

        public  async Task<IActionResult> success()
        {
            ViewBag.Host = _appSettingsService.GetURl();
            TempData["person"] = TempData["UserName"];
            TempData["showAlert"] = true;

            return View("ContactUs");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using TamTechSDK.Common.Models.Pagination;
using TamTechSDK.Common.Services.ContentService.Menus;
using TamTechSDK.Common.Services.ContentService.Posts;
using TamTechSDK.Common.Services.ContentService.Posts.Models;
using TamTechSDK.Common.Services.ContentService.Sections;
using TamTechSDK.Common.Services.ContentService.Sections.Models;
using TamTechSDK.Common.Services.Upload;
using TamTechSDK.Web;
using TamTechSDK.Web.Controllers.Portal;
using TamTechSDK.Web.Services.Telemetry;

namespace EmtEvents.Areas.Portal.Controllers
{
    public class PostsController : PostsBaseController
    {
        private IPostsService _postservice;
        private ISectionsService _SectionsService;
        public PostsController(ITelemetryClientService telemetryClientService,
            IMenusServices menusServices,
            IPostsService postservice, ISectionsService SectionsService)
            : base(telemetryClientService, menusServices, postservice, SectionsService)
        {
            _postservice = postservice;
            _SectionsService = SectionsService;
        }


        [ActionName("s")]
        public override async Task<IActionResult> Section(PaginationModel Pagination, string slug)
        {
            try
            {

                ViewBag.slug = slug;
                var sectionContainer = await _SectionsService.GetPublicSectionWithLatestSubSectionsBySlugAsync(slug);

                if (sectionContainer == null || sectionContainer.SectionInfo == null)
                {
                    return NotFound();
                }

                // When there is no sectionInfo there can be no posts
                PostsList pagedPosts = sectionContainer?.SectionInfo != null ? await _postservice.GetPublicLatestPostsBySectionSlugAsync(Pagination, slug) : new PostsList();

                SectionContainerDto model = new SectionContainerDto
                {
                    Sections = sectionContainer.Sections,
                    SectionInfo = sectionContainer.SectionInfo,
                    Posts = pagedPosts.Data,
                    Pagination = pagedPosts.Pagination
                };

                return View("Index", model);
            }
            catch (Exception ex)
            {
                TrackException(ex);
            }

            return NotFound();

        }
    }



}
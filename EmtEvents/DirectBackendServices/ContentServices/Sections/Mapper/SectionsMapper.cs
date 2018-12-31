using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmtEvents.DirectBackendServices.ContentServices.Posts.Mapper;
using TamTechSDK.Common.Models.ContentItem;
using TamTechSDK.Common.Providers.Requests.Models;
using TamTechSDK.Common.Services.ContentService.Sections;
using TamTechSDK.Common.Services.ContentService.Sections.Models;

namespace EmtEvents.DirectBackendServices.ContentServices.Sections.Mapper
{
    public static class SectionsMapper
    {



        public static TamTechBackendSDK.ContentService.Services.Sections.Dtos.CreateSectionModel MapTobackendCreateSection(this TamTechSDK.Common.Services.ContentService.Sections.Models.CreateSectionDto item)
        {
            return new TamTechBackendSDK.ContentService.Services.Sections.Dtos.CreateSectionModel
            {

                DisplayOrder = item.DisplayOrder,
                Lang = item.Lang,
                MainImage = item.MainImage,
                Slug = item.Slug,
                Summary = item.Summary,
                Title = item.Title,
                ParentId = item.ParentId,
                MetaDescription = item.MetaDescription,
            };
        }


        public static TamTechSDK.Common.Services.ContentService.Sections.Models.SectionDto MapToFrontendDto(this TamTechBackendSDK.ContentService.Services.Sections.Dtos.SectionDto backend)
        {
            return new TamTechSDK.Common.Services.ContentService.Sections.Models.SectionDto
            {
                Id = backend.Id,
                ParentId = backend.ParentId,
                ParentName = backend.ParentTitle,
                DisplayOrder = backend.DisplayOrder,
                Lang = backend.Lang,
                MainImage = backend.MainImage,
                Slug = backend.Slug,
                SlugHierarchy = backend.SlugHierarchy,
                Summary = backend.Summary,
                Title = backend.Title,
                CreatedDate = backend.CreatedDate,
                Published = backend.Published,
                MetaDescription = backend.MetaDescription,
                SEOMarkup = backend.SEOMarkup,
                ModifiedDate = backend.ModifiedDate,
                Locked = backend.Locked,
                PublishedDate = backend.PublishedDate,
                //  Posts = backend.Posts?.Select(p => p.MapToFrontendDto(backend.SlugHierarchy)).ToList() 
            };
        }


        public static TamTechBackendSDK.ContentService.Services.Sections.Dtos.UpdateSectionModel MapToBackendDto(this TamTechSDK.Common.Services.ContentService.Sections.Models.UpdateSectionDto frontend)
        {
            return new TamTechBackendSDK.ContentService.Services.Sections.Dtos.UpdateSectionModel
            {
                Id = frontend.Id,
                ParentId = frontend.ParentId,
                DisplayOrder = frontend.DisplayOrder,
                Lang = frontend.Lang,
                MainImage = frontend.MainImage,
                Slug = frontend.Slug,
                Summary = frontend.Summary,
                Title = frontend.Title,
                MetaDescription = frontend.MetaDescription,
                SEOMarkup = frontend.SEOMarkup,
            };
        }

        public static TamTechSDK.Common.Services.ContentService.Sections.Models.SectionContainerDto MapToContainerDto(this TamTechBackendSDK.ContentService.Services.Sections.Dtos.SectionContainerDto item)
        {
            return new TamTechSDK.Common.Services.ContentService.Sections.Models.SectionContainerDto
            {
                SectionInfo = item.SectionInfo?.MapToFrontendDto(),
                Sections = item.Sections != null ? item.Sections.Select(m => m.MapToFrontendDto()).ToList() : new List<SectionDto>(),
                Posts = item.Posts != null ? item.Posts.Select(p => p.MapToFrontendDto()).ToList() : new List<TamTechSDK.Common.Services.ContentService.Posts.Models.PostDto>()
            };
        }
    }
}

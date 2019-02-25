using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmtEvents.DirectBackendServices.ContentServices.Posts.Mapper
{
    public static class PostMapper
    {
        public static TamTechBackendSDK.ContentService.Services.Posts.Dtos.CreatePostModel MapToBackendDto(this TamTechSDK.Common.Services.ContentService.Posts.Models.CreatePostDto frontend)
        {
            return new TamTechBackendSDK.ContentService.Services.Posts.Dtos.CreatePostModel
            {
                Content = frontend.Content,
                DisplayOrder = frontend.DisplayOrder,
                Lang = frontend.Lang,
                MainImage = frontend.MainImage,
                Section = frontend.Section,
                SectionId = frontend.SectionId,
                Slug = frontend.Slug,
                Summary = frontend.Summary,
                Title = frontend.Title,
                MetaDescription = frontend.MetaDescription,
                Tags = frontend.Tags,
                CustomDate = frontend.PostDate
            };
        }

        public static TamTechBackendSDK.ContentService.Services.Posts.Dtos.UpdatePostModel MapToBackendDto(this TamTechSDK.Common.Services.ContentService.Posts.Models.UpdatePostDto frontend)
        {
            return new TamTechBackendSDK.ContentService.Services.Posts.Dtos.UpdatePostModel
            {
                Id = frontend.Id,
                Content = frontend.Content,
                DisplayOrder = frontend.DisplayOrder,
                Lang = frontend.Lang,
                MainImage = frontend.MainImage,
                Slug = frontend.Slug,
                Summary = frontend.Summary,
                Title = frontend.Title,
                SectionId = frontend.SectionId,
                SectionName = frontend.Section,
                MetaDescription = frontend.MetaDescription,
                SEOMarkup = frontend.SEOMarkup,
                Tags = frontend.Tags,
                CustomDate = frontend.PostDate
            };
        }


        public static TamTechSDK.Common.Services.ContentService.Posts.Models.PostDto MapToFrontendDto(this TamTechBackendSDK.ContentService.Services.Posts.Dtos.PostDto backend)
        {
            return new TamTechSDK.Common.Services.ContentService.Posts.Models.PostDto
            {
                Id = backend.Id,
                Content = backend.Content,
                DisplayOrder = backend.DisplayOrder,
                Lang = backend.Lang,
                MainImage = backend.MainImage,
                Section = backend.SectionTitle,
                Slug = backend.Slug,
                Summary = backend.Summary,
                SectionId = backend.SectionId,
                Title = backend.Title,
                CreatedDate = backend.CreatedDate,
                Published = backend.Published,
                MetaDescription = backend.MetaDescription,
                SEOMarkup = backend.SEOMarkup,
                ModifiedDate = backend.ModifiedDate,
                Locked = backend.Locked,
                PublishedDate = backend.PublishedDate,
                AuthorName = backend.AuthorName,
                SectionSlug = backend.SectionSlug,
                ViewsCount = backend.VisitorsCount,
                PostDate =backend.CustomDate
                //Tags = backend.Tags
            };
        }

        public static TamTechSDK.Common.Services.ContentService.Posts.Models.PostDto MapToPublicFrontendDto(this TamTechBackendSDK.ContentService.Services.Posts.Dtos.PostDto backend)
        {
            TamTechSDK.Common.Services.ContentService.Posts.Models.PostDto dto = backend.MapToFrontendDto();

            //dto.SectionSlug = backend.SectionSlug;

            return dto;
        }



    }
}

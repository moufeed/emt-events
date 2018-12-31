using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmtEvents.DirectBackendServices.ContentServices.Services.Mapper
{
    public static class ServiceMapper
    {
        public static TamTechBackendSDK.ContentService.Services.Dtos.CreateServiceModel MapToBackendDto(this TamTechSDK.Common.Services.ContentService.Services.Models.CreateServiceDto frontend)
        {
            return new TamTechBackendSDK.ContentService.Services.Dtos.CreateServiceModel
            {
                Content = frontend.Content,
                DisplayOrder = frontend.DisplayOrder,
                Lang = frontend.Lang,
                MainImage = frontend.MainImage,
                Section = frontend.Section,
                Slug = frontend.Slug,
                Summary = frontend.Summary,
                Title = frontend.Title,
                Icon = frontend.Icon,
                IconVisibility = frontend.IconVisibility,
                MetaDescription = frontend.MetaDescription,
            };
        }

        public static TamTechBackendSDK.ContentService.Services.Dtos.UpdateServiceModel MapToBackendDto(this TamTechSDK.Common.Services.ContentService.Services.Models.UpdateServiceDto frontend)
        {
            return new TamTechBackendSDK.ContentService.Services.Dtos.UpdateServiceModel
            {
                Id = frontend.Id,
                Content = frontend.Content,
                DisplayOrder = frontend.DisplayOrder,
                Lang = frontend.Lang,
                MainImage = frontend.MainImage,
                Section = frontend.Section,
                Slug = frontend.Slug,
                Summary = frontend.Summary,
                Title = frontend.Title,
                Icon = frontend.Icon,
                IconVisibility = frontend.IconVisibility,
                MetaDescription = frontend.MetaDescription,
                SEOMarkup = frontend.SEOMarkup,
            };
        }


        public static TamTechSDK.Common.Services.ContentService.Services.Models.ServiceDto MapToFrontendDto(this TamTechBackendSDK.ContentService.Services.Dtos.ServiceDto backend)
        {
            return new TamTechSDK.Common.Services.ContentService.Services.Models.ServiceDto
            {
                Id = backend.Id,
                Content = backend.Content,
                DisplayOrder = backend.DisplayOrder,
                Lang = backend.Lang,
                MainImage = backend.MainImage,
                Section = backend.Section,
                Slug = backend.Slug,
                Summary = backend.Summary,
                Title = backend.Title,
                CreatedDate = backend.CreatedDate,
                Published = backend.Published,
                Icon = backend.Icon,
                IconVisibility = backend.IconVisibility,
                MetaDescription = backend.MetaDescription,
                SEOMarkup = backend.SEOMarkup,
                ModifiedDate = backend.ModifiedDate,
                Locked = backend.Locked,
                PublishedDate = backend.PublishedDate
            };
        }

    }
}

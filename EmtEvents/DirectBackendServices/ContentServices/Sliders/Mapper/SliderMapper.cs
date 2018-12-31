using System.Collections.Generic;
using System.Linq;
using TamTechSDK.Common.Services.ContentService.Sliders.Models;

namespace EmtEvents.DirectBackendServices.ContentServices.Sliders.Mapper
{
    public static class SliderMapper
    {
        public static SliderDto MapToFrontendSliderDto(this TamTechBackendSDK.ContentService.Services.Sliders.Dtos.SliderDto backend)
        {
            return new SliderDto
            {
                Id = backend.Id,
                Lang = backend.Lang,
                Title = backend.Title,
                Key = backend.Key,
                //  Slug = backend.Slug,
                Summary = backend.Summary,
                //  Position = backend.Position,
                //  DisplayOrder = backend.DisplayOrder,
                CreatedDate = backend.CreatedDate,
                ModifiedDate = backend.ModifiedDate,
                Published = backend.Published,
                Locked = backend.Locked,
                Items = backend.Items != null ? backend.Items.Where(item => !item.Deleted)
                                                                     .Select(p => p.MapToFrontendDto())
                                                                     .OrderBy(m => m.DisplayOrder)
                                                                     .ToList() : new List<SliderItemDto>()
            };
        }

        public static SliderDto MapToFrontendSliderDto(this TamTechBackendSDK.ContentService.Services.Sliders.Dtos.PublicSliderDto backend)
        {
            return new SliderDto
            {
                Id = backend.Id,
                Lang = backend.Lang,
                Title = backend.Title,
                Key = backend.Key,
                //  Slug = backend.Slug,
                Summary = backend.Summary,
                //  Position = backend.Position,
                //  DisplayOrder = backend.DisplayOrder,
                CreatedDate = backend.CreatedDate,
                ModifiedDate = backend.ModifiedDate,
                Published = backend.Published,
                Items = backend.Items != null ? backend.Items.Where(item => !item.Deleted)
                                                                     .Select(p => p.MapToFrontendDto())
                                                                     .OrderBy(m => m.DisplayOrder)
                                                                     .ToList() : new List<SliderItemDto>()
            };
        }

        public static TamTechBackendSDK.ContentService.Services.Sliders.Dtos.CreateSliderModel MapToBackendDto(this CreateSliderDto frontend)
        {
            return new TamTechBackendSDK.ContentService.Services.Sliders.Dtos.CreateSliderModel
            {
                Lang = frontend.Lang,
                Title = frontend.Title,
                Key = frontend.Key,
                // Slug = frontend.Slug,
                Summary = frontend.Summary,
                // Position = frontend.Position,
            };
        }

        public static TamTechBackendSDK.ContentService.Services.Sliders.Dtos.UpdateSliderModel MapToBackendUpdateSliderDto(this UpdateSliderDto frontend)
        {
            return new TamTechBackendSDK.ContentService.Services.Sliders.Dtos.UpdateSliderModel
            {
                Id = frontend.Id,
                Lang = frontend.Lang,
                Title = frontend.Title,
                Key = frontend.Key,
                //  Slug = frontend.Slug,
                Summary = frontend.Summary,
                //  Position = frontend.Position

            };
        }

        public static TamTechBackendSDK.ContentService.Services.Sliders.Dtos.SliderItemKeysModel MapToBackendDto(this SliderItemKeysDto frontend)
        {
            return new TamTechBackendSDK.ContentService.Services.Sliders.Dtos.SliderItemKeysModel
            {
                SliderId = frontend.SliderId,
                Id = frontend.Id,
            };
        }

        public static TamTechBackendSDK.ContentService.Services.Sliders.Dtos.PublishSliderItemModel MapToBackendPublishDto(this SliderItemKeysDto frontend)
        {
            return new TamTechBackendSDK.ContentService.Services.Sliders.Dtos.PublishSliderItemModel
            {
                SliderId = frontend.SliderId,
                Id = frontend.Id,
                Lang = frontend.Lang,
            };
        }

        public static SliderItemDto MapToFrontendDto(this TamTechBackendSDK.ContentService.Services.Sliders.Dtos.SliderItemDto backend)
        {
            return new SliderItemDto
            {

                Id = backend.Id,
                //    SliderId = backend.SliderId,
                Lang = backend.Lang,
                Title = backend.Title,
                MainImage = backend.Image,
                Url = backend.Url,
                UrlTarget = backend.UrlTarget,
                Published = backend.Published,
                DisplayOrder = backend.DisplayOrder,
                Summary = backend.Summary,
                CreatedDate = backend.CreatedDate

            };
        }

        public static TamTechBackendSDK.ContentService.Services.Sliders.Dtos.CreateSliderItemModel MapToBackendDto(this CreateSliderItemDto frontend)
        {
            return new TamTechBackendSDK.ContentService.Services.Sliders.Dtos.CreateSliderItemModel
            {

                Lang = frontend.Lang,
                SliderId = frontend.SliderId,
                Title = frontend.Title,
                Image = frontend.MainImage,
                Url = frontend.Url,
                UrlTarget = frontend.UrlTarget,
                DisplayOrder = frontend.DisplayOrder,
                Summary = frontend.Summary

            };
        }
        //------------------------------------------------------------
        public static TamTechBackendSDK.ContentService.Services.Sliders.Dtos.UpdateSliderItemModel MapToBackendDto(this UpdateSliderItemDto frontend)
        {
            return new TamTechBackendSDK.ContentService.Services.Sliders.Dtos.UpdateSliderItemModel
            {
                Id = frontend.Id,
                Title = frontend.Title,
                Lang = frontend.Lang,
                SliderId = frontend.SliderId,
                Image = frontend.MainImage,
                Url = frontend.Url,
                UrlTarget = frontend.UrlTarget,
                DisplayOrder = frontend.DisplayOrder,
                Summary = frontend.Summary,


            };
        }
    }
}

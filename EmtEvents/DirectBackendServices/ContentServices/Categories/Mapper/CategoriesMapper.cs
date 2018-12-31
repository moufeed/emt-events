using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmtEvents.DirectBackendServices.ContentServices.Categories.Mapper
{
    public static class CategoriesMapper
    {

        public static TamTechBackendSDK.ContentService.Dtos.Product.CategoryDto MapToBackendDto(this TamTechSDK.Common.Services.ContentService.Categories.Models.Category frontend)
        {
            return new TamTechBackendSDK.ContentService.Dtos.Product.CategoryDto
            {
                Name = frontend.Name,
                ImageUrl = frontend.ImageUrl,
                Description = frontend.Description,
                CategoryType = frontend.CategoryType,
                //MetaDescription = frontend.MetaDescription,
                //SEOMarkup = frontend.SEOMarkup,
                // Lang = frontend.Lang,
                // PublishedDate = frontend.PublishedDate,
                // ModifiedDate = frontend.ModifiedDate
            };
        }



        public static TamTechSDK.Common.Services.ContentService.Categories.Models.Category MapToFrontendCategory(this TamTechBackendSDK.ContentService.Dtos.Product.CategoryDto item)
        {
            return new TamTechSDK.Common.Services.ContentService.Categories.Models.Category
            {
                Id = item.Id,
                Name = item.Name,
                ImageUrl = item.ImageUrl,
                Description = item.Description,
                CategoryType = item.CategoryType,
                //MetaDescription = item.MetaDescription,
                //SEOMarkup = item.SEOMarkup,
                // Lang = item.Lang,
                // PublishedDate = item.PublishedDate,
                // ModifiedDate = item.ModifiedDate
            };
        }
    }
}

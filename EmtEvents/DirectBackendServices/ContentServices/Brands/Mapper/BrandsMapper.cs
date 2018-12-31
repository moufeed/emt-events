using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmtEvents.DirectBackendServices.ContentServices.Brands.Mapper
{
    public static class BrandsMapper
    {

        public static TamTechBackendSDK.ContentService.Dtos.Product.CategoryDto MapToBackendCategoryDto(this TamTechSDK.Common.Services.ContentService.Categories.Models.Category frontend)
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



        public static TamTechBackendSDK.ContentService.Dtos.Product.BrandDto MapToBackendBrandDto(this TamTechSDK.Common.Services.ContentService.Brands.Models.Brand item)
        {
            return new TamTechBackendSDK.ContentService.Dtos.Product.BrandDto
            {

                Lang = item.Lang,
                Id = item.Id,
                Name = item.Name,
                ImageUrl = item.ImageUrl,
                Order = item.Order,
                Categories = item.Categories != null ? item.Categories.Select(m => m.MapToBackendCategoryDto()).ToList() : new List<TamTechBackendSDK.ContentService.Dtos.Product.CategoryDto>(),
                //MetaDescription = item.MetaDescription,
                //PublishedDate = item.PublishedDate,
                //ModifiedDate = item.ModifiedDate,
                //SEOMarkup = item.SEOMarkup,
            };
        }




        public static TamTechSDK.Common.Services.ContentService.Categories.Models.Category MapToFrontendCategory(this TamTechBackendSDK.ContentService.Dtos.Product.CategoryDto frontend)
        {
            return new TamTechSDK.Common.Services.ContentService.Categories.Models.Category
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


        public static TamTechSDK.Common.Services.ContentService.Brands.Models.Brand MapToFrontendBrand(this TamTechBackendSDK.ContentService.Dtos.Product.BrandDto item)
        {
            return new TamTechSDK.Common.Services.ContentService.Brands.Models.Brand
            {
                Lang = item.Lang,
                Id = item.Id,
                Name = item.Name,
                ImageUrl = item.ImageUrl,
                Order = item.Order,
                Categories = item.Categories != null ? item.Categories.Select(m => m.MapToFrontendCategory()).ToList() : new List<TamTechSDK.Common.Services.ContentService.Categories.Models.Category>(),
                //MetaDescription = item.MetaDescription,
                //PublishedDate = item.PublishedDate,
                //ModifiedDate = item.ModifiedDate,
                //SEOMarkup = item.SEOMarkup,
            };
        }
    }
}

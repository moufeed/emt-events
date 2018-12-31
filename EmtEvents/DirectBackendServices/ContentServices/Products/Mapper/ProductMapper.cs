using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmtEvents.DirectBackendServices.ContentServices.Products.Mapper
{
    public static class ProductMapper
    {

        #region Mapping to Backend
        public static TamTechBackendSDK.ContentService.Dtos.Product.ProductAttributeValueDto MapToAttributeValueDto(this TamTechSDK.Common.Services.ContentService.Products.Models.ProductAttributeValue item)
        {
            return new TamTechBackendSDK.ContentService.Dtos.Product.ProductAttributeValueDto
            {
                Value = item.Value,
                Price = item.Price,
                Lang = item.Lang

            };
        }

        public static TamTechBackendSDK.ContentService.Dtos.Product.ProductAttributeDto MapToBackendAttributeDto(this TamTechSDK.Common.Services.ContentService.Products.Models.ProductAttribute item)
        {
            return new TamTechBackendSDK.ContentService.Dtos.Product.ProductAttributeDto
            {
                Type = item.Type,
                Name = item.Name,
                Values = item.Values != null ? item.Values.Select(m => m.MapToAttributeValueDto()).ToList() : new List<TamTechBackendSDK.ContentService.Dtos.Product.ProductAttributeValueDto>(),
                Lang = item.Lang
            };
        }

        public static TamTechBackendSDK.ContentService.Dtos.Product.ProductAttributeModel MapToBackendAttributeFormDto(this TamTechSDK.Common.Services.ContentService.Products.Models.ProductAttributeForm item)
        {
            return new TamTechBackendSDK.ContentService.Dtos.Product.ProductAttributeModel
            {
                ProductId = item.ProductId,
                Type = item.Type,
                Name = item.Name,
                Lang = item.Lang
            };
        }

        public static TamTechBackendSDK.ContentService.Dtos.Product.ProductAttributeValueModel MapToBackendAttributeValueForm(this TamTechSDK.Common.Services.ContentService.Products.Models.ProductAttributeValueForm item)
        {
            return new TamTechBackendSDK.ContentService.Dtos.Product.ProductAttributeValueModel
            {

                Value = item.Value,
                AttributeName = item.AttributeName,
                ProductId = item.ProductId,
                Price = item.Price,
                Lang = item.Lang
            };
        }

        public static TamTechBackendSDK.ContentService.Dtos.Product.ProductAttributeKeysDto MapToBackendAttributeKeysDto(this TamTechSDK.Common.Services.ContentService.Products.Models.ProductAttributeKeys item)
        {
            return new TamTechBackendSDK.ContentService.Dtos.Product.ProductAttributeKeysDto
            {
                Name = item.Name,
                ProductId = item.ProductId,
                Lang = item.Lang
            };
        }

        public static TamTechBackendSDK.ContentService.Dtos.Product.ProductAttributeValueKeysDto MapToBackendAttributeValueKeysDto(this TamTechSDK.Common.Services.ContentService.Products.Models.ProductAttributeValueKeys item)
        {
            return new TamTechBackendSDK.ContentService.Dtos.Product.ProductAttributeValueKeysDto
            {
                AttributeName = item.AttributeName,
                ProductId = item.ProductId,
                Value = item.Value,
                Lang = item.Lang
            };
        }

        public static TamTechBackendSDK.ContentService.Dtos.Product.UpdateProductAttributeModel MapToAttributeEditingDto(this TamTechSDK.Common.Services.ContentService.Products.Models.ProductAttributeEditing item)
        {
            return new TamTechBackendSDK.ContentService.Dtos.Product.UpdateProductAttributeModel
            {
                ProductId = item.ProductId,
                Type = item.Type,
                OriginalName = item.OriginalName,
                Name = item.Name,
                ReturnProductCombinations = item.ReturnProductCombinations,
                Lang = item.Lang

            };
        }

        public static TamTechBackendSDK.ContentService.Dtos.Product.UpdateProductAttributeValueModel MapToBackendAttributeValueEditingDto(this TamTechSDK.Common.Services.ContentService.Products.Models.ProductAttributeValueEditing item)
        {
            return new TamTechBackendSDK.ContentService.Dtos.Product.UpdateProductAttributeValueModel
            {

                OriginalValue = item.OriginalValue,
                AttributeName = item.AttributeName,
                ProductId = item.ProductId,
                Value = item.Value,
                Price = item.Price,
                ReturnProductCombinations = item.ReturnProductCombinations,
                Lang = item.Lang
            };
        }

        public static TamTechBackendSDK.ContentService.Dtos.Product.ProductCombinationDto MapToBackendCombinationDto(this TamTechSDK.Common.Services.ContentService.Products.Models.ProductCombination item)
        {
            return new TamTechBackendSDK.ContentService.Dtos.Product.ProductCombinationDto
            {
                AttributesValues = item.AttributesValues,
                Sku = item.Sku,
                Quantity = item.Quantity,
                Price = item.Price,
                DiscountPrice = item.DiscountPrice,
                Published = item.Published,
                Lang = item.Lang
            };
        }

        public static TamTechBackendSDK.ContentService.Dtos.Product.ProductCombinationModel MapToBackendCombinationFormDto(this TamTechSDK.Common.Services.ContentService.Products.Models.ProductCombinationForm item)
        {
            return new TamTechBackendSDK.ContentService.Dtos.Product.ProductCombinationModel
            {
                ProductId = item.ProductId,
                Attributes = item.AttributesValues,
                Sku = item.Sku,
                Quantity = item.Quantity,
                Price = item.Price,
                DiscountPrice = item.DiscountPrice,
                Lang = item.Lang

            };
        }

        public static TamTechBackendSDK.ContentService.Dtos.Product.ProductCombinationKeysDto MapToBackendCombinationKeysDto(this TamTechSDK.Common.Services.ContentService.Products.Models.ProductCombinationKeys item)
        {
            return new TamTechBackendSDK.ContentService.Dtos.Product.ProductCombinationKeysDto
            {
                ProductId = item.ProductId,
                CombinationKey = item.CombinationKey,
                Sku = item.Sku,
                Lang = item.Lang
            };
        }

        public static TamTechBackendSDK.ContentService.Dtos.Product.ProductDto MapToBackendDTO(this TamTechSDK.Common.Services.ContentService.Products.Models.ProductForm item)
        {
            return new TamTechBackendSDK.ContentService.Dtos.Product.ProductDto
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                ShortDescription = item.ShortDescription,
                FullDescription = item.FullDescription,
                StockQuantity = item.StockQuantity,
                DiscountPrice = item.DiscountPrice,
                Price = item.Price,
                Published = item.Published,
                MainImageUrl = item.MainImageUrl,
                SKU = item.SKU,
                Rate = item.Rate,
                CategoriesIds = item.CategoriesIds,
                BrandId = item.BrandId,
                MaximumCartQuantity = item.MaximumCartQuantity,
                IsShipEnabled = item.IsShipEnabled,
                IsFreeShipping = item.IsFreeShipping,
                Weight = item.Weight,
                Length = item.Length,
                Width = item.Width,
                Height = item.Height,
                Specifications = item.Specifications,
                Attributes = item.Attributes != null ? item.Attributes.Select(m => m.MapToBackendAttributeDto()).ToList() : new List<TamTechBackendSDK.ContentService.Dtos.Product.ProductAttributeDto>(),
                Images = item.Images,
                Combinations = item.Combinations != null ? item.Combinations.Select(m => m.MapToBackendCombinationDto()).ToList() : new List<TamTechBackendSDK.ContentService.Dtos.Product.ProductCombinationDto>(),
                MetaDescription = item.MetaDescription,
                SEOMarkup = item.SEOMarkup,
                Lang = item.Lang,
                // PublishedDate = item.PublishedDate,
                // ModifiedDate = item.ModifiedDate
            };
        }


        public static TamTechBackendSDK.ContentService.Dtos.Product.UpdateProductDto MapToBackendUpdateDTO(this TamTechSDK.Common.Services.ContentService.Products.Models.ProductForm item)
        {
            return new TamTechBackendSDK.ContentService.Dtos.Product.UpdateProductDto
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                ShortDescription = item.ShortDescription,
                FullDescription = item.FullDescription,
                StockQuantity = item.StockQuantity,
                DiscountPrice = item.DiscountPrice,
                Price = item.Price,
                Published = item.Published,
                MainImageUrl = item.MainImageUrl,
                SKU = item.SKU,
                Rate = item.Rate,
                CategoriesIds = item.CategoriesIds,
                BrandId = item.BrandId,
                MaximumCartQuantity = item.MaximumCartQuantity,
                IsShipEnabled = item.IsShipEnabled,
                IsFreeShipping = item.IsFreeShipping,
                Weight = item.Weight,
                Length = item.Length,
                Width = item.Width,
                Height = item.Height,
                Specifications = item.Specifications,
                //  Attributes = item.Attributes != null ? item.Attributes.Select(m => m.MapToBackendAttributeDto()).ToList() : new List<TamTechBackendSDK.ContentService.Dtos.Product.ProductAttributeDto>(),
                Images = item.Images,
                //  Combinations = item.Combinations != null ? item.Combinations.Select(m => m.MapToBackendCombinationDto()).ToList() : new List<TamTechBackendSDK.ContentService.Dtos.Product.ProductCombinationDto>(),
                MetaDescription = item.MetaDescription,
                SEOMarkup = item.SEOMarkup,
                Lang = item.Lang,
                // PublishedDate = item.PublishedDate,
                // ModifiedDate = item.ModifiedDate
            };
        }

        public static TamTechBackendSDK.ContentService.Dtos.Product.CreateProductDto MapToBackendCreateDTO(this TamTechSDK.Common.Services.ContentService.Products.Models.ProductForm item)
        {
            return new TamTechBackendSDK.ContentService.Dtos.Product.CreateProductDto
            {
                Name = item.Name,
                Description = item.Description,
                ShortDescription = item.ShortDescription,
                FullDescription = item.FullDescription,
                StockQuantity = item.StockQuantity,
                DiscountPrice = item.DiscountPrice,
                Price = item.Price,
                Published = item.Published,
                MainImageUrl = item.MainImageUrl,
                SKU = item.SKU,
                Rate = item.Rate,
                CategoriesIds = item.CategoriesIds,
                BrandId = item.BrandId,
                MaximumCartQuantity = item.MaximumCartQuantity,
                IsShipEnabled = item.IsShipEnabled,
                IsFreeShipping = item.IsFreeShipping,
                Weight = item.Weight,
                Length = item.Length,
                Width = item.Width,
                Height = item.Height,
                Specifications = item.Specifications,
                //      Attributes = item.Attributes != null ? item.Attributes.Select(m => m.MapToBackendAttributeDto()).ToList() : new List<TamTechBackendSDK.ContentService.Dtos.Product.ProductAttributeDto>(),
                Images = item.Images,
                //    Combinations = item.Combinations != null ? item.Combinations.Select(m => m.MapToBackendCombinationDto()).ToList() : new List<TamTechBackendSDK.ContentService.Dtos.Product.ProductCombinationDto>(),
                MetaDescription = item.MetaDescription,
                SEOMarkup = item.SEOMarkup,
                Lang = item.Lang,
                // PublishedDate = item.PublishedDate,
                // ModifiedDate = item.ModifiedDate
            };
        }
        public static TamTechBackendSDK.ContentService.Services.Shared.Dtos.PublishModel MapToBackendPublishDt(this TamTechSDK.Common.Services.ContentService.Products.Models.PublishDto item)
        {
            return new TamTechBackendSDK.ContentService.Services.Shared.Dtos.PublishModel
            {
                Id = item.Id,
                Lang = item.Lang
            };
        }

        public static TamTechBackendSDK.ContentService.Dtos.Product.ProductImagesKeysDto MapToBackendImagesKeysDto(this TamTechSDK.Common.Services.ContentService.Products.Models.ProductImagesModel item)
        {
            return new TamTechBackendSDK.ContentService.Dtos.Product.ProductImagesKeysDto
            {
                ProductId = item.ProductId,
                images = item.images,
                Lang = item.Lang
            };
        }
        #endregion



        #region Mapping to frontend


        public static TamTechSDK.Common.Services.ContentService.Products.Models.ProductCombination MapToFronendCombination(this TamTechBackendSDK.ContentService.Dtos.Product.ProductCombinationDto item)
        {
            return new TamTechSDK.Common.Services.ContentService.Products.Models.ProductCombination
            {
                AttributesValues = item.AttributesValues,
                Sku = item.Sku,
                Quantity = item.Quantity,
                Price = item.Price,
                DiscountPrice = item.DiscountPrice,
                Published = item.Published,
                Lang = item.Lang,
            };
        }

        public static TamTechSDK.Common.Services.ContentService.Products.Models.CombinationResultModel MapToFrontendCombinationResultModel(this TamTechBackendSDK.ContentService.Services.Products.Models.CombinationResultModel item)
        {
            return new TamTechSDK.Common.Services.ContentService.Products.Models.CombinationResultModel
            {
                Key = item.Key,
                Sku = item.Sku
            };
        }


        public static TamTechSDK.Common.Services.ContentService.Products.Models.ProductAttributeValue MapToFrontendAttributeValue(this TamTechBackendSDK.ContentService.Dtos.Product.ProductAttributeValueDto item)
        {
            return new TamTechSDK.Common.Services.ContentService.Products.Models.ProductAttributeValue
            {
                Value = item.Value,
                Price = item.Price,
                Lang = item.Lang
            };
        }

        public static TamTechSDK.Common.Services.ContentService.Products.Models.ProductAttribute MapToFrontendAttribute(this TamTechBackendSDK.ContentService.Dtos.Product.ProductAttributeDto item)
        {
            return new TamTechSDK.Common.Services.ContentService.Products.Models.ProductAttribute
            {
                Type = item.Type,
                Name = item.Name,
                Values = item.Values != null ? item.Values.Select(m => m.MapToFrontendAttributeValue()).ToList() : new List<TamTechSDK.Common.Services.ContentService.Products.Models.ProductAttributeValue>(),
                Lang = item.Lang
            };

        }

        public static TamTechSDK.Common.Services.ContentService.Products.Models.Product MapToFrontendProduct(this TamTechBackendSDK.ContentService.Dtos.Product.ProductDto item)
        {
            return new TamTechSDK.Common.Services.ContentService.Products.Models.Product
            {
                Combinations = item.Combinations != null ? item.Combinations.Select(m => m.MapToFronendCombination()).ToList() : new List<TamTechSDK.Common.Services.ContentService.Products.Models.ProductCombination>(),
                Images = item.Images,
                Attributes = item.Attributes != null ? item.Attributes.Select(m => m.MapToFrontendAttribute()).ToList() : new List<TamTechSDK.Common.Services.ContentService.Products.Models.ProductAttribute>(),
                Specifications = item.Specifications,
                Height = item.Height,
                Width = item.Width,
                Length = item.Length,
                Weight = item.Weight,
                IsFreeShipping = item.IsFreeShipping,
                IsShipEnabled = item.IsShipEnabled,
                MaximumCartQuantity = item.MaximumCartQuantity,
                //  BrandId = item.BrandId,
                MetaDescription = item.MetaDescription,
                //  Categories = item.CategoriesIds,
                //Slug = item.Slug,
                SKU = item.SKU,
                MainImageUrl = item.MainImageUrl,
                Published = item.Published,
                Price = item.Price,
                DiscountPrice = item.DiscountPrice,
                StockQuantity = item.StockQuantity,
                FullDescription = item.FullDescription,
                ShortDescription = item.ShortDescription,
                Description = item.Description,
                Name = item.Name,
                Id = item.Id,
                Rate = item.Rate,
                SEOMarkup = item.SEOMarkup,
                Lang = item.Lang
                // PublishedDate = item.PublishedDate,
                //ModifiedDate = item.ModifiedDate
            };
        }

        public static TamTechSDK.Common.Services.ContentService.Products.Models.ProductForm MapToFrontendProductForm(this TamTechBackendSDK.ContentService.Dtos.Product.ProductDto item)
        {
            return new TamTechSDK.Common.Services.ContentService.Products.Models.ProductForm
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                ShortDescription = item.ShortDescription,
                FullDescription = item.FullDescription,
                StockQuantity = item.StockQuantity,
                DiscountPrice = item.DiscountPrice,
                Price = item.Price,
                Published = item.Published,
                MainImageUrl = item.MainImageUrl,
                SKU = item.SKU,
                Rate = item.Rate,
                CategoriesIds = item.CategoriesIds,
                BrandId = item.BrandId,
                MaximumCartQuantity = item.MaximumCartQuantity,
                IsShipEnabled = item.IsShipEnabled,
                IsFreeShipping = item.IsFreeShipping,
                Weight = item.Weight,
                Length = item.Length,
                Width = item.Width,
                Height = item.Height,
                Specifications = item.Specifications,
                Attributes = item.Attributes != null ? item.Attributes.Select(m => m.MapToFrontendAttribute()).ToList() : new List<TamTechSDK.Common.Services.ContentService.Products.Models.ProductAttribute>(),
                Images = item.Images,
                Combinations = item.Combinations != null ? item.Combinations.Select(m => m.MapToFronendCombination()).ToList() : new List<TamTechSDK.Common.Services.ContentService.Products.Models.ProductCombination>(),
                Lang = item.Lang,
                MetaDescription = item.MetaDescription,
                //PublishedDate = item.PublishedDate,
                //ModifiedDate = item.ModifiedDate,
                SEOMarkup = item.SEOMarkup,
            };
        }
        #endregion
    }
}


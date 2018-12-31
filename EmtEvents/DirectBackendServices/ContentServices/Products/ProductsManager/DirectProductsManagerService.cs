using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmtEvents.DirectBackendServices.ContentServices.Products.Mapper;
using TamTechSDK.Common.Models.Pagination;
using TamTechSDK.Common.Models.Sort;
using TamTechSDK.Common.Providers.Requests.Models;
using TamTechSDK.Common.Services.ContentService.Products.Models;

namespace EmtEvents.DirectBackendServices.ContentServices.Products
{
    public class DirectProductsManagerService : BaseDirectService, TamTechSDK.Common.Services.ContentService.Products.IProductsManagerService
    {

        private readonly TamTechBackendSDK.ContentService.Services.Products.IProductService _productService;



        public DirectProductsManagerService(TamTechBackendSDK.ContentService.Services.Products.IProductService productService)
        {
            _productService = productService;
        }


        public async Task<IRequestProviderResult<Guid>> CreateAsync(ProductForm model)
        {
            var result = await _productService.CreateAsync(model.MapToBackendCreateDTO());

            return MapRequestProviderResult<Guid>(result);

        }

        public async Task<IRequestProviderResult<bool>> CreateProductAttributeAsync(ProductAttributeForm model)
        {
            var result = await _productService.CreateProductAttributeAsync(model.MapToBackendAttributeFormDto());

            return MapRequestProviderResult<bool>(result);
        }

        public async Task<IRequestProviderResult<bool>> CreateProductAttributeValueAsync(ProductAttributeValueForm model)
        {
            var result = await _productService.CreateProductAttributeValueAsync(model.MapToBackendAttributeValueForm());
            return MapRequestProviderResult<bool>(result);
        }

        public async Task<IRequestProviderResult<CombinationResultModel>> CreateProductCombinationAsync(ProductCombinationForm model)
        {
            var result = await _productService.CreateProductCombinationAsync(model.MapToBackendCombinationFormDto());
            // return ReturnResult(result.Data?.MapToFrontendCombinationResultModel(), result.Success, result.StatusCode); 
            //   var data = result.Data != null ? result.Data.Select(m => m.MapToFronendCombination()).ToList() : new List<ProductCombination>();

            return ReturnResult(result, result.Data?.MapToFrontendCombinationResultModel());

        }

        public async Task<IRequestProviderResult<bool>> DeleteAsync(Guid id)
        {
            var result = await _productService.HardDeleteAsync(id);
            return MapRequestProviderResult<bool>(result);
        }

        public async Task<IRequestProviderResult<bool>> DeleteProductAttributeAsync(ProductAttributeKeys model)
        {
            var result = await _productService.HardDeleteProductAttributeAsync(model.MapToBackendAttributeKeysDto());

            return MapRequestProviderResult<bool>(result);
        }

        public async Task<IRequestProviderResult<bool>> DeleteProductAttributeValueAsync(ProductAttributeValueKeys model)
        {
            var result = await _productService.HardDeleteProductAttributeValueAsync(model.MapToBackendAttributeValueKeysDto());
            return MapRequestProviderResult<bool>(result);
        }



        public async Task<IRequestProviderResult<bool>> DeleteProductCombinationAsync(ProductCombinationKeys model)
        {
            var result = await _productService.HardDeleteProductCombinationAsync(model.MapToBackendCombinationKeysDto());
            return MapRequestProviderResult<bool>(result);
        }



        public async Task<IRequestProviderResult<bool>> DeleteProductImagesValueAsync(ProductImagesModel model)
        {
            var result = await _productService.HardDeleteProductImagesAsync(model.MapToBackendImagesKeysDto());
            return MapRequestProviderResult<bool>(result);
        }

        public async Task<IRequestProviderResult<bool>> EditAsync(ProductForm model)
        {
            var result = await _productService.EditAsync(model.MapToBackendUpdateDTO());

            return MapRequestProviderResult<bool>(result);

        }

        public async Task<IRequestProviderResult<List<ProductCombination>>> EditProductAttributeAndGetCompinationsAsync(ProductAttributeEditing model)
        {
            var result = await _productService.EditProductAttributeAndGetCompinationsAsync(model.MapToAttributeEditingDto());

            var data = result.Data != null ? result.Data.Select(m => m.MapToFronendCombination()).ToList() : new List<ProductCombination>();

            return ReturnResult(result, data);
        }

        public async Task<IRequestProviderResult<bool>> EditProductAttributeAsync(ProductAttributeEditing model)
        {
            var result = await _productService.EditProductAttributeAsync(model.MapToAttributeEditingDto());
            return MapRequestProviderResult<bool>(result);
        }

        public async Task<IRequestProviderResult<List<ProductCombination>>> EditProductAttributeValueAndGetCompinationsAsync(ProductAttributeValueEditing model)
        {
            var result = await _productService.EditProductAttributeValueAndGetCompinationsAsync(model.MapToBackendAttributeValueEditingDto());

            var data = result.Data != null ? result.Data.Select(m => m.MapToFronendCombination()).ToList() : new List<ProductCombination>();

            return ReturnResult(result, data);

        }

        public async Task<IRequestProviderResult<bool>> EditProductAttributeValueAsync(ProductAttributeValueEditing model)
        {
            var result = await _productService.EditProductAttributeValueAsync(model.MapToBackendAttributeValueEditingDto());
            return MapRequestProviderResult<bool>(result);

        }

        public async Task<IRequestProviderResult<List<Product>>> GetAllAsync(string lang)
        {
            var result = await _productService.GetAllExceptSoftDeletedAsync(lang);

            var data = result != null ? result.Select(m => m.MapToFrontendProduct()).ToList() : new List<Product>();

            return ReturnResult(data, result != null);

        }

        public async Task<IRequestProviderResult<List<Product>>> GetAllAsync(PaginationModel pagination, Dictionary<string, object> searchParams, SortingModel sorting, string lang)
        {

            /*
              var result = await _productService.GetAllExceptSoftDeletedAsync(pagination.MapToBackendPaginationModel(), searchParams, sorting.MapToBackendSortingModel(), lang);

             ProductsList model = new ProductsList
             {
                 Data = result.Data != null  ? result.Data.Select(m => m.MapToFrontendProduct()).ToList() : new List<Product>(),
                 Pagination = result.Pagination?.MapToForntEndPagination()
             };

             return ReturnResult(model);

         */


            throw new NotImplementedException();


        }



        public Task<IRequestProviderResult<List<Product>>> GetAsync(PagingParameterModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<IRequestProviderResult<ProductForm>> GetByIdAsync(Guid id, string lang)
        {
            var result = await _productService.GetByIdExceptSoftDeletedAsync(id, lang);

            return ReturnResult(result.MapToFrontendProductForm(), result != null);

        }

        public async Task<IRequestProviderResult<List<ProductAttribute>>> GetProductAttributesAsync(Guid productId, string lang)
        {
            var result = await _productService.GetProductAttributesAsync(productId, lang);

            var data = result != null ? result.Select(m => m.MapToFrontendAttribute()).ToList() : new List<ProductAttribute>();

            return ReturnResult(data, result != null);

        }


        public async Task<IRequestProviderResult<List<ProductCombination>>> GetProductCombinationsAsync(Guid productId, string lang)
        {
            var result = await _productService.GetProductCombinationsAsync(productId, lang);

            var data = result != null ? result.Select(m => m.MapToFronendCombination()).ToList() : new List<ProductCombination>();

            return ReturnResult(data, result != null);

        }

        public async Task<IRequestProviderResult<bool>> PublishAsync(PublishDto model)
        {
            var result = await _productService.PublishAsync(model.MapToBackendPublishDt());

            return MapRequestProviderResult<bool>(result);
        }

        public async Task<IRequestProviderResult<bool>> PublishProductCombinationAsync(ProductCombinationKeys model)
        {
            var result = await _productService.PublishProductCombinationAsync(model.MapToBackendCombinationKeysDto());

            return MapRequestProviderResult<bool>(result);
        }
    }
}

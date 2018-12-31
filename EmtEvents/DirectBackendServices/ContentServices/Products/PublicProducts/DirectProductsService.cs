using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamTechSDK.Common.Models.Pagination;
using TamTechSDK.Common.Providers.Requests.Models;
using TamTechSDK.Common.Services.ContentService.Products.Models;

namespace EmtEvents.DirectBackendServices.ContentServices.Products
{
    public class DirectProductsService : TamTechSDK.Common.Services.ContentService.Products.IProductsService
    {
        private readonly TamTechBackendSDK.ContentService.Services.Products.IProductService _productService;

        public DirectProductsService(TamTechBackendSDK.ContentService.Services.Products.IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IRequestProviderResult<ProductForm>> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IRequestProviderResult<List<Product>>> GetPaginationWithGenericFiltrationAsync(PaginateWithFilterModel model)
        {
            throw new NotImplementedException();
        }

        public Task<IRequestProviderResult<Product>> GetPublicDynamicByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IRequestProviderResult<List<Product>>> GetPublicDynamicListByFiltrationAsync(PublicProductFiltrationModel model)
        {
            throw new NotImplementedException();
        }

        public Task<dynamic> GetPublicDynamicListByIdsAsync(IEnumerable<Guid> ids)
        {
            throw new NotImplementedException();
        }

        public Task<IRequestProviderResult<List<Product>>> GetPublicDynamicListBySKUsAsync(IEnumerable<string> skus)
        {
            throw new NotImplementedException();
        }
    }
}

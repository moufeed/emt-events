using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmtEvents.DirectBackendServices.ContentServices.Categories.Mapper;
using TamTechSDK.Common.Providers.Requests.Models;
using TamTechSDK.Common.Services.ContentService.Categories.Models;
using TamTechSDK.Common.Services.ContentService.Categories;
namespace EmtEvents.DirectBackendServices.ContentServices.Categories
{
    public class DirectCategoriesServices : BaseDirectService, ICategoriesServices
    {

        #region Props  
        private readonly TamTechBackendSDK.ContentService.Services.Categorys.ICategoryService _categoryService;
        #endregion


        public DirectCategoriesServices(TamTechBackendSDK.ContentService.Services.Categorys.ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        #region Services 

        #region {Public Categories}   

        public async Task<dynamic> GetPublicDynamicListAsync()
        {
            throw new Exception("GetCategoryByIdAsync not found!");
            // return GetDataResult(await _requestProvider.GetAsync<dynamic>(_backendSettings.GetPublicDynamicListAsyncEndpoint));
        }


        #endregion



        #region {Categories Manager}   
        public async Task<IRequestProviderResult<Guid>> CreateAsync(Category model)
        {
            var result = await _categoryService.CreateAsync(model.MapToBackendDto());

            return MapRequestProviderResult<Guid>(result);

        }
        public async Task<IRequestProviderResult<List<Category>>> GetAsync(string lang)
        {
            var result = await _categoryService.GetAsync(lang);

            var data = result != null ? result.Select(m => m.MapToFrontendCategory()).ToList() : new List<Category>();

            return ReturnResult(data, result != null);
        }




        public async Task<IRequestProviderResult<object>> DeleteCategoryByIdAsync(string id)
        {
            return new RequestProviderResult<object>
            {
                Success = true
            };
        }


        public async Task<IRequestProviderResult<List<Category>>> GetCategoriesAsync()
        {
            throw new Exception("GetCategoriesAsync not found!");
        }

        public async Task<IRequestProviderResult<Category>> GetCategoryByIdAsync(string id)
        {
            throw new Exception("GetCategoryByIdAsync not found!");
        }
        #endregion


        #endregion
    }
}

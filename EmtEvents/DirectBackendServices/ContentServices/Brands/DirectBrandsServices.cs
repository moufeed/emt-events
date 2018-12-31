using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmtEvents.DirectBackendServices.ContentServices.Brands.Mapper;
using TamTechSDK.Common.Providers.Requests.Models;
using TamTechSDK.Common.Services.ContentService.Brands.Models;

namespace EmtEvents.DirectBackendServices.ContentServices.Brands
{
    public class DirectBrandsServices : BaseDirectService, TamTechSDK.Common.Services.ContentService.Brands.IBrandsServices
    {

        #region Props  
        private readonly TamTechBackendSDK.ContentService.Services.Brands.IBrandService _brandService;
        #endregion



        public DirectBrandsServices(TamTechBackendSDK.ContentService.Services.Brands.IBrandService brandService)
        {
            _brandService = brandService;
        }


        #region {Public Brands}   

        public async Task<dynamic> GetPublicDynamicListAsync()
        {
            throw new Exception("GetPublicDynamicListAsync not found!");
        }


        #endregion



        #region {Brands Manager}   
        public async Task<IRequestProviderResult<Guid>> CreateAsync(Brand model)
        {
            var result = await _brandService.CreateAsync(model.MapToBackendBrandDto());

            return MapRequestProviderResult<Guid>(result);

        }
        public async Task<IRequestProviderResult<List<Brand>>> GetAsync(string lang)
        {
            var result = await _brandService.GetAsync(lang);

            var data = result != null ? result.Select(m => m.MapToFrontendBrand()).ToList() : new List<Brand>();

            return ReturnResult(data, result != null);


        }

        public async Task<IRequestProviderResult<object>> DeleteBrandByIdAsync(string id)
        {
            return new RequestProviderResult<object>
            {
                Success = true
            };
        }

        public async Task<IRequestProviderResult<Brand>> GetBrandByIdAsync(string id)
        {
            throw new Exception("GetBrandByIdAsync not found!");
        }

        public async Task<IRequestProviderResult<List<Brand>>> GetBrandsListAsync()
        {
            throw new Exception("GetBrandsListAsync not found!");
        }

        #endregion


    }
}

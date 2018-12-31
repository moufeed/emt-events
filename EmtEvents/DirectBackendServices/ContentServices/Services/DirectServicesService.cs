using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmtEvents.DirectBackendServices.ContentServices.Services.Mapper;
using TamTechSDK.Common.Models.ContentItem;
using TamTechSDK.Common.Models.Pagination;
using TamTechSDK.Common.Models.Sort;
using TamTechSDK.Common.Providers.Requests.Models;
using TamTechSDK.Common.Services.ContentService.Services;
using TamTechSDK.Common.Services.ContentService.Services.Models;

namespace EmtEvents.DirectBackendServices.ContentServices.Services
{
    public class DirectServicesService : BaseDirectService, TamTechSDK.Common.Services.ContentService.Services.IServicesService
    {

        #region Props  
        private readonly TamTechBackendSDK.ContentService.Services.Services.IServicesModuleService _servicesService;
        #endregion


        #region Ctors
        public DirectServicesService(TamTechBackendSDK.ContentService.Services.Services.IServicesModuleService servicesService)
        {
            _servicesService = servicesService;
        }
        #endregion

        #region Utilities

        private IRequestProviderResult<TResult> MapRequestProviderResult<TResult>(
           TamTechBackendSDK.ContentService.Models.Results.IReturnResultModel<TResult> inputResult)
        {
            IRequestProviderResult<TResult> _resultModel = new RequestProviderResult<TResult>();
            _resultModel.Success = inputResult.Success;
            _resultModel.StatusCode = (System.Net.HttpStatusCode)((int)inputResult.StatusCode);
            _resultModel.Data = inputResult.Data;
            _resultModel.Messages = _resultModel.Success ? null : _resultModel.Messages = new Dictionary<string, List<string>>();
            foreach (var error in inputResult.ModelState)
            {
                var errorMessages = new List<string>();
                if (error.Value.Errors.Count > 0)
                {
                    foreach (var value in error.Value.Errors)
                    {
                        errorMessages.Add(value.ErrorMessage);
                    }

                    _resultModel.Messages.Add(error.Key, errorMessages);
                }
            }
            return _resultModel;
        }

        private IRequestProviderResult<TResult> GetRequestProviderResult<TResult>(TResult data)
        {
            IRequestProviderResult<TResult> _resultModel = new RequestProviderResult<TResult>();
            _resultModel.Success = true;
            _resultModel.StatusCode = System.Net.HttpStatusCode.OK;
            _resultModel.Data = data;
            return _resultModel;
        }
        #region Deserialize
        public TResult DeserializeFromObject<TResult>(dynamic inputObject)
        {
            string serialized = JsonConvert.SerializeObject(inputObject);
            TResult handledResult = JsonConvert.DeserializeObject<TResult>(serialized);
            return handledResult;
        }
        #endregion

        #endregion

        #region Services

        #region {Public Services}  

        public async Task<IRequestProviderResult<ServiceDto>> GetPublicBySlugAsync(string slug)
        {
            //// TODO: Not optimized
            //dynamic result = await _servicesService.GetPublicDynamicBySlugAsync(slug);
            //ServiceDto page = new ServiceDto();
            //if (result != null)
            //{
            //    page = DeserializeFromObject<ServiceDto>(result);
            //}
            //return GetRequestProviderResult(page);
            var service = await _servicesService.GetPublicBySlugAsync(slug);
            return GetRequestProviderResult(service?.MapToFrontendDto());
        }




        public async Task<IRequestProviderResult<List<ServiceDto>>> GetPublicListAsync(string slug = "")
        {
            var services = await _servicesService.GetPublicListAsync(slug);
            List<ServiceDto> servicesDto = services?.Select(m => m.MapToFrontendDto()).ToList();
            return GetRequestProviderResult(servicesDto);
        }

        public async Task<IRequestProviderResult<List<ServiceDto>>> GetPublicListAsync()
        {
            //// TODO: Not optimized
            //dynamic result = await _servicesService.GetPublicDynamicListAsync();
            //List<ServiceDto> ServicesList = new List<ServiceDto>(); 
            //if (result != null)
            //{
            //    ServicesList = DeserializeFromObject<List<ServiceDto>>(result);
            //}
            //return GetRequestProviderResult(ServicesList);
            var services = await _servicesService.GetPublicListAsync();
            List<ServiceDto> servicesDto = services?.Select(m => m.MapToFrontendDto()).ToList();
            return GetRequestProviderResult(servicesDto);
        }


        public async Task<IRequestProviderResult<List<ServiceDto>>> GetPublicListAsync(int takeItems)
        {
            //// TODO: Not optimized
            //dynamic result = await _servicesService.GetPublicDynamicListAsync(takeItems);
            //List<ServiceDto> ServicesList = new List<ServiceDto>();
            //if (result != null)
            //{
            //    ServicesList = DeserializeFromObject<List<ServiceDto>>(result);
            //}
            //return GetRequestProviderResult(ServicesList); 

            var services = await _servicesService.GetPublicListAsync(takeItems);
            List<ServiceDto> servicesDto = services != null ? services.Select(m => m.MapToFrontendDto()).ToList() : new List<ServiceDto>();
            return GetRequestProviderResult(servicesDto);
        }
        #endregion

        #region {Services Manager}  


        public async Task<IRequestProviderResult<ServiceList>> GetAllAsync(PaginationModel pagination, Dictionary<string, object> searchParams, SortingModel sorting, string lang)
        {

            var result = await _servicesService.GetAllExceptSoftDeletedAsync(pagination.MapToBackendPaginationModel(), searchParams, sorting.MapToBackendSortingModel(), lang);

            ServiceList model = new ServiceList
            {
                Data = result.Data != null ? result.Data.Select(m => m.MapToFrontendDto()).ToList() : new List<ServiceDto>(),
                Pagination = result.Pagination?.MapToForntEndPagination()
            };

            return ReturnResult(model);



        }



        public async Task<IRequestProviderResult<ServiceDto>> GetByIdAsync(Guid id, string lang)
        {
            var service = await _servicesService.GetByIdExceptSoftDeletedAsync(id, lang);
            return GetRequestProviderResult(service?.MapToFrontendDto());
        }

        public async Task<IRequestProviderResult<Guid>> CreateAsync(CreateServiceDto model)
        {
            var result = await _servicesService.CreateAsync(model.MapToBackendDto());
            return MapRequestProviderResult(result);
        }

        public async Task<IRequestProviderResult<bool>> EditAsync(UpdateServiceDto model)
        {
            var result = await _servicesService.EditAsync(model.MapToBackendDto());
            return MapRequestProviderResult(result);
        }

        public async Task<IRequestProviderResult<bool>> DeleteAsync(Guid id)
        {
            var result = await _servicesService.SoftDeleteAsync(id);
            return MapRequestProviderResult(result);
        }

        public async Task<IRequestProviderResult<bool>> PublishAsync(PublishDTO data)
        {
            var result = await _servicesService.PublishAsync(data.MapToBackend());
            return MapRequestProviderResult(result);
        }






        #endregion

        #endregion
    }
}

using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmtEvents.DirectBackendServices.ContentServices.Sliders.Mapper;
using TamTechSDK.Common.Models.ContentItem;
using TamTechSDK.Common.Providers.Requests.Models;
using TamTechSDK.Common.Services.ContentService.Sliders.Models;

namespace EmtEvents.DirectBackendServices.ContentServices.Sliders
{
    public class DirectSlidersService : TamTechSDK.Common.Services.ContentService.Sliders.ISlidersServices
    {
        #region Props  
        private readonly TamTechBackendSDK.ContentService.Services.Sliders.ISliderService _sliderService;
        private readonly IConfiguration _configuration;
        #endregion

        #region Ctors
        public DirectSlidersService(TamTechBackendSDK.ContentService.Services.Sliders.ISliderService sliderService,
            IConfiguration configuration)
        {
            _sliderService = sliderService;
            _configuration = configuration;
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


        #region Public Slider


        public async Task<IRequestProviderResult<SliderDto>> GetPublicByKeyAsync(string key)
        {
            var result = await _sliderService.GetPublicByKeyAsync(key);
            return GetRequestProviderResult(result.MapToFrontendSliderDto());
        }


        #endregion


        #region Sliders

        #region  GetAll / Get /  Create / Edit / Delete / Publish

        public async Task<IRequestProviderResult<List<SliderDto>>> GetAllAsync(string lang)
        {
            var sliders = await _sliderService.GetAllExceptSoftDeletedAsync(lang);
            var slidersList = sliders == null ?
                new List<SliderDto>() : sliders.Select(item => item.MapToFrontendSliderDto()).ToList();
            return GetRequestProviderResult(slidersList);
        }


        public async Task<IRequestProviderResult<SliderDto>> GetByIdAsync(Guid id, string lang)
        {
            var slider = await _sliderService.GetByIdExceptSoftDeletedAsync(id, lang);
            return GetRequestProviderResult(slider.MapToFrontendSliderDto());
        }


        public async Task<IRequestProviderResult<Guid>> CreateASync(CreateSliderDto slider)
        {
            var result = await _sliderService.CreateAsync(slider.MapToBackendDto());
            return MapRequestProviderResult(result);
        }

        public async Task<IRequestProviderResult<bool>> UpdateAsync(UpdateSliderDto slider)
        {
            var result = await _sliderService.EditAsync(slider.MapToBackendUpdateSliderDto());
            return MapRequestProviderResult(result);
        }

        public async Task<IRequestProviderResult<bool>> DeleteByIdAsync(Guid id)
        {
            var result = await _sliderService.SoftDeleteAsync(id);
            return MapRequestProviderResult(result);
        }

        public async Task<IRequestProviderResult<bool>> publishByIdAsync(PublishDTO data)
        {
            var result = await _sliderService.PublishAsync(data.MapToBackend());
            return MapRequestProviderResult(result);
        }


        #endregion

        #endregion



        #region Slider Items 

        #region  Get / Create / Edit / Delete / Publish

        public async Task<IRequestProviderResult<SliderItemDto>> GetSliderItemByIdAsync(SliderItemKeysDto model, string lang)
        {
            var result = await _sliderService.GetSliderItemByIdAsync(model.MapToBackendDto(), lang);
            return GetRequestProviderResult(result.MapToFrontendDto());

        }

        public async Task<IRequestProviderResult<Guid>> CreateSliderItemASync(CreateSliderItemDto slider)
        {
            var result = await _sliderService.CreateSliderItemAsync(slider.MapToBackendDto());
            return MapRequestProviderResult(result);
        }

        public async Task<IRequestProviderResult<bool>> UpdateSliderItemAsync(UpdateSliderItemDto slider)
        {
            var result = await _sliderService.EditSliderItemAsync(slider.MapToBackendDto());
            return MapRequestProviderResult(result);
        }

        public async Task<IRequestProviderResult<bool>> DeleteSliderItemByIdAsync(SliderItemKeysDto model)
        {
            var result = await _sliderService.HardDeleteSliderItemAsync(model.MapToBackendDto());
            return MapRequestProviderResult(result);
        }

        public async Task<IRequestProviderResult<bool>> publishSliderItemByIdAsync(SliderItemKeysDto model)
        {
            var result = await _sliderService.PublishSliderItemAsync(model.MapToBackendPublishDto());
            return MapRequestProviderResult(result);
        }


        #endregion

        #endregion


    }
}

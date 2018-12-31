using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using TamTechSDK.Common.Providers.Requests.Models;

namespace EmtEvents.DirectBackendServices
{
    public class BaseDirectService
    {

        #region Props  
        public readonly string _lang;
        public readonly string _culture;
        #endregion


        #region Ctors
        public BaseDirectService()
        {
            _lang = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            _culture = CultureInfo.CurrentCulture.Name;
        }
        #endregion

        #region Utilities

        public IRequestProviderResult<TResult> MapRequestProviderResult<TResult>(
           TamTechBackendSDK.ContentService.Models.Results.IReturnResultModel<TResult> inputResult)
        {
            IRequestProviderResult<TResult> _resultModel = new RequestProviderResult<TResult>();
            _resultModel.Success = inputResult.Success;
            _resultModel.StatusCode = (System.Net.HttpStatusCode)((int)inputResult.StatusCode);
            _resultModel.Data = inputResult.Data;
            _resultModel.Messages = _resultModel.Success ? null : _resultModel.Messages = new Dictionary<string, List<string>>();
            foreach (KeyValuePair<string, Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateEntry> error in inputResult.ModelState)
            {
                List<string> errorMessages = new List<string>();
                if (error.Value.Errors.Count > 0)
                {
                    foreach (Microsoft.AspNetCore.Mvc.ModelBinding.ModelError value in error.Value.Errors)
                    {
                        errorMessages.Add(value.ErrorMessage);
                    }

                    _resultModel.Messages.Add(error.Key, errorMessages);
                }
            }
            return _resultModel;
        }

        public IRequestProviderResult<TResult> MapRequestProviderResult<TResult>(
           TamTechBackendSDK.IdentityService.Models.IReturnResultModel<TResult> inputResult)
        {
            IRequestProviderResult<TResult> _resultModel = new RequestProviderResult<TResult>();
            _resultModel.Success = inputResult.Success;
            _resultModel.StatusCode = inputResult.StatusCode;
            _resultModel.Data = inputResult.Data;
            _resultModel.Messages = _resultModel.Success ? null : _resultModel.Messages = new Dictionary<string, List<string>>();
            foreach (KeyValuePair<string, Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateEntry> error in inputResult.ModelState)
            {
                List<string> errorMessages = new List<string>();
                if (error.Value.Errors.Count > 0)
                {
                    foreach (Microsoft.AspNetCore.Mvc.ModelBinding.ModelError value in error.Value.Errors)
                    {
                        errorMessages.Add(value.ErrorMessage);
                    }

                    _resultModel.Messages.Add(error.Key, errorMessages);
                }
            }
            return _resultModel;
        }

        public IRequestProviderResult<TResult> ReturnResult<TResult>(TResult data, bool Success = true, System.Net.HttpStatusCode statusCode = System.Net.HttpStatusCode.OK)
        {
            IRequestProviderResult<TResult> _resultModel = new RequestProviderResult<TResult>();
            _resultModel.Success = Success;
            _resultModel.StatusCode = statusCode;
            _resultModel.Data = data;
            return _resultModel;
        }


        public IRequestProviderResult<TOutputResult> ReturnResult<TOutputResult, TInputResult>(TamTechBackendSDK.ContentService.Models.Results.IReturnResultModel<TInputResult> inputResult, TOutputResult data)
        {
            IRequestProviderResult<TOutputResult> _resultModel = new RequestProviderResult<TOutputResult>();
            _resultModel.Messages = inputResult.Success ? null : _resultModel.Messages = new Dictionary<string, List<string>>();
            foreach (KeyValuePair<string, Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateEntry> error in inputResult.ModelState)
            {
                List<string> errorMessages = new List<string>();
                if (error.Value.Errors.Count > 0)
                {
                    foreach (Microsoft.AspNetCore.Mvc.ModelBinding.ModelError value in error.Value.Errors)
                    {
                        errorMessages.Add(value.ErrorMessage);
                    }

                    _resultModel.Messages.Add(error.Key, errorMessages);
                }
            }
            _resultModel.Success = inputResult.Success;
            _resultModel.StatusCode = (System.Net.HttpStatusCode)((int)inputResult.StatusCode);
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


    }
}

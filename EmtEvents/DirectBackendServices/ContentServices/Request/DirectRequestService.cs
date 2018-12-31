using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmtEvents.DirectBackendServices.ContentServices.Request.Mapper;

using TamTechSDK.Common.Models.Pagination;
using TamTechSDK.Common.Models.SelectList;
using TamTechSDK.Common.Models.Sort;
using TamTechSDK.Common.Providers.Requests.Models;
using TamTechSDK.Common.Services.ContentService.Request;
using TamTechSDK.Common.Services.ContentService.Request.Models;

namespace EmtEvents.DirectBackendServices.ContentServices.Request
{
    public class DirectRequestService : BaseDirectService, IRequestService
    {
        #region Props  
        private readonly TamTechBackendSDK.ContentService.Services.Requests.IRequestService _RequestService;
        #endregion

        #region constructor
        public DirectRequestService(TamTechBackendSDK.ContentService.Services.Requests.IRequestService RequestService)
        {
            _RequestService = RequestService;
        }

        #endregion



        #region create update status

        public async Task<IRequestProviderResult<Guid>> CreateAsync(CreateRequestModel model)
        {
            var result = await _RequestService.CreateAsync(model.MapToBackEndCreateRequestModel());

            return MapRequestProviderResult(result);
        }


        public async Task<IRequestProviderResult<bool>> UpdateRequestStatusAsync(UpdateRequestStatusModel model)
        {
            var result = await _RequestService.UpdateRequestStatusAsync(model.MapToBackEndUpdateRequestStatusModel());

            return MapRequestProviderResult(result);
        }

        #endregion

        #region Get
        public async Task<IRequestProviderResult<PagedResultModel<List<RequestDto>>>> GetAllExceptSoftDeletedAsync(PaginationModel pagination, Dictionary<string, object> searchParams, SortingModel sorting, string lang)
        {
            var result = await _RequestService.GetAllExceptSoftDeletedAsync(pagination.MapToBackendPaginationModel(), searchParams, sorting.MapToBackendSortingModel(), lang);

            PagedResultModel<List<RequestDto>> model = new PagedResultModel<List<RequestDto>>
            {
                Data = result.Data?.Select(m => m.MapToFrontendDto()).ToList(),
                Pagination = result.Pagination?.MapToForntEndPagination()
            };

            return ReturnResult(model);

        }



        public async Task<IRequestProviderResult<List<SelectListItemModel>>> GetItemsListExceptSoftDeletedAsync(string lang)
        {
            var result = await _RequestService.GetItemsListExceptSoftDeletedAsync(lang);

            List<SelectListItemModel> SelectListItem = result != null ? result.Select(m => m.MapToFrontendSelectListItemModel()).ToList() : new List<SelectListItemModel>();

            return ReturnResult(SelectListItem);
        }

        public async Task<IRequestProviderResult<RequestDto>> GetByIdAsync(Guid id, string lang)
        {
            var result = await _RequestService.GetByIdExceptSoftDeletedAsync(id, lang);

            return ReturnResult(result.MapToFrontendDto(), result != null);
        }


        public async Task<List<RequestHistoryDto>> GetRequestHistoriesListByRequestIdAsync(Guid requestId, string lang)
        {
            var result = await _RequestService.GetRequestHistoriesListByRequestIdAsync(requestId, lang);

            return result?.Select(m => m.MapToFrontendRequestHistoryDto()).ToList();
        }

        #endregion



        #region public services
        public async Task<IRequestProviderResult<List<SelectListItemModel>>> GetPublicItemsListAsync()
        {
            var result = await _RequestService.GetPublicItemsListAsync();

            List<SelectListItemModel> SelectListItem = result != null ? result.Select(m => m.MapToFrontendSelectListItemModel()).ToList() : new List<SelectListItemModel>();

            return ReturnResult(SelectListItem);
        }



        #endregion
    }
}

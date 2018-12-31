using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace EmtEvents.DirectBackendServices.ContentServices.Request.Mapper
{
    public static class RequestMapper
    {

        public static TamTechSDK.Common.Models.SelectList.SelectListItemModel MapToFrontendSelectListItemModel(this TamTechBackendSDK.ContentService.Models.SelectListItemModel item)
        {
            return new TamTechSDK.Common.Models.SelectList.SelectListItemModel
            {
                Text = item.Text,
                Value = item.Value
            };
        }


        public static TamTechBackendSDK.ContentService.Services.Requests.Models.RequestModel MapToBackendRequestModel(this TamTechSDK.Common.Services.ContentService.Request.Models.RequestModel item)
        {

            return new TamTechBackendSDK.ContentService.Services.Requests.Models.RequestModel
            {
                ItemId = item.ItemId,
                CityId = item.CityId,
                StatusId = item.StatusId,
                Quantity = item.Quantity,
                ItemPrice = item.ItemPrice,
                FullName = item.FullName,
                Email = item.Email,
                Mobile = item.Mobile,
                Phone = item.Phone,
                Address = item.Address,
                ZipCode = item.ZipCode,
                Notes = item.Notes
            };
        }

        public static TamTechSDK.Common.Services.ContentService.Request.Models.RequestModel MapToFrontendRequestModel(this TamTechBackendSDK.ContentService.Services.Requests.Models.RequestModel item)
        {

            return new TamTechSDK.Common.Services.ContentService.Request.Models.RequestModel
            {
                ItemId = item.ItemId,
                CityId = item.CityId,
                StatusId = item.StatusId,
                Quantity = item.Quantity,
                ItemPrice = item.ItemPrice,
                FullName = item.FullName,
                Email = item.Email,
                Mobile = item.Mobile,
                Phone = item.Phone,
                Address = item.Address,
                ZipCode = item.ZipCode,
                Notes = item.Notes
            };
        }


        public static TamTechBackendSDK.ContentService.Services.Requests.Models.CreateRequestModel MapToBackEndCreateRequestModel(this TamTechSDK.Common.Services.ContentService.Request.Models.CreateRequestModel item)
        {
            return new TamTechBackendSDK.ContentService.Services.Requests.Models.CreateRequestModel
            {
                ItemId = item.ItemId,
                CityId = item.CityId,
                StatusId = item.StatusId,
                Quantity = item.Quantity,
                ItemPrice = item.ItemPrice,
                FullName = item.FullName,
                Email = item.Email,
                Mobile = item.Mobile,
                Phone = item.Phone,
                Address = item.Address,
                ZipCode = item.ZipCode,
                Notes = item.Notes
            };
        }


        public static TamTechBackendSDK.ContentService.Services.Requests.Models.UpdateRequestStatusModel MapToBackEndUpdateRequestStatusModel(this TamTechSDK.Common.Services.ContentService.Request.Models.UpdateRequestStatusModel item)
        {
            return new TamTechBackendSDK.ContentService.Services.Requests.Models.UpdateRequestStatusModel
            {
                Id = item.Id,
                CurrentStatusId = item.CurrentStatusId,
                StatusId = item.StatusId,
                Notes = item.Notes,
            };
        }

        public static TamTechSDK.Common.Services.ContentService.Request.Models.RequestDto MapToFrontendDto(this TamTechBackendSDK.ContentService.Services.Requests.Models.RequestDto item)
        {

            return new TamTechSDK.Common.Services.ContentService.Request.Models.RequestDto
            {
                ItemId = item.ItemId,
                CityId = item.CityId,
                StatusId = item.StatusId,
                Quantity = item.Quantity,
                ItemPrice = item.ItemPrice,
                FullName = item.FullName,
                Email = item.Email,
                Mobile = item.Mobile,
                Phone = item.Phone,
                Address = item.Address,
                ZipCode = item.ZipCode,
                Notes = item.Notes,
                Id = item.Id,
                CreatedDate = item.CreatedDate,
                LastModifiedDate = item.LastModifiedDate,
                StatusName = item.StatusName,
                CityName = item.CityName,
            };
        }

        #region filters / Pagination
        public static TamTechSDK.Common.Models.Pagination.PaginationMetadataModel MapToForntEndPagination(this TamTechBackendSDK.ContentService.Models.PaginationMetadataModel item)
        {
            return new TamTechSDK.Common.Models.Pagination.PaginationMetadataModel
            {
                TotalCount = item.TotalCount,
                PageSize = item.PageSize,
                PageNumber = item.PageNumber,
                TotalPages = item.TotalPages,
                PreviousPage = item.PreviousPage,
                NextPage = item.NextPage
            };
        }

        public static TamTechBackendSDK.ContentService.Models.PaginationParamsModel MapToBackendPaginationModel(this TamTechSDK.Common.Models.Pagination.PaginationModel item)
        {
            return new TamTechBackendSDK.ContentService.Models.PaginationParamsModel
            {
                PageNumber = item.PageNumber,
                PageSize = item.PageSize
            };
        }

        public static TamTechBackendSDK.ContentService.Models.SortingModel MapToBackendSortingModel(this TamTechSDK.Common.Models.Sort.SortingModel item)
        {
            return new TamTechBackendSDK.ContentService.Models.SortingModel
            {
                SortBy = item.SortBy,
                Descending = item.Descending
            };
        }
        #endregion


        #region  history
        public static TamTechSDK.Common.Services.ContentService.Request.Models.RequestHistoryDto MapToFrontendRequestHistoryDto(this TamTechBackendSDK.ContentService.Services.Requests.Models.RequestHistoryDto item)
        {
            return new TamTechSDK.Common.Services.ContentService.Request.Models.RequestHistoryDto
            {
                Id = item.Id,
                RequestId = item.RequestId,
                CurrentStatusId = item.CurrentStatusId,
                PreviousStatusId = item.PreviousStatusId,
                UserId = item.UserId,
                Notes = item.Notes,
                ProcessDate = item.ProcessDate,
                CurrentStatusName = item.CurrentStatusName,
                PreviousStatusName = item.PreviousStatusName

            };
        }
        #endregion
    }
}

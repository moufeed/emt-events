using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmtEvents.DirectBackendServices.ContentServices
{
    public static class Mapper
    {

        public static TamTechBackendSDK.ContentService.Services.Shared.Dtos.PublishModel MapToBackend(this TamTechSDK.Common.Models.ContentItem.PublishDTO frontend)
        {
            return new TamTechBackendSDK.ContentService.Services.Shared.Dtos.PublishModel
            {
                Id = frontend.Id,
                Lang = frontend.Lang,

            };
        }


        public static TamTechSDK.Common.Models.SelectList.SelectListItemModel MapToFrontEndSelectListItemModel(this TamTechBackendSDK.ContentService.Models.SelectListItemModel item)
        {
            return new TamTechSDK.Common.Models.SelectList.SelectListItemModel
            {
                Text = item.Text,
                Value = item.Value
            };
        }




        public static TamTechBackendSDK.ContentService.Models.PaginationParamsModel toBackendPaginationModel(this TamTechSDK.Common.Models.Pagination.PaginationModel item)
        {
            return new TamTechBackendSDK.ContentService.Models.PaginationParamsModel
            {
                PageNumber = item.PageNumber,
                PageSize = item.PageSize
            };
        }





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
    }
}

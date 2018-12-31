using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmtEvents.DirectBackendServices.ContentServices.Content.Mapper
{
    public static class ContentMapper
    {

        public static TamTechSDK.Common.Services.ContentService.ContentService.Models.NumericalStatisticsDto MapToFrontEndNumericalStatisticsDto(this TamTechBackendSDK.ContentService.Services.Content.Models.NumericalStatisticsDto item)
        {
            return new TamTechSDK.Common.Services.ContentService.ContentService.Models.NumericalStatisticsDto
            {
                Count = item.Count,
                PublishedCount = item.PublishedCount,
                UnpublishedCount = item.UnpublishedCount

            };
        }

    }
}

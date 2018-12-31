using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmtEvents.DirectBackendServices.ContentServices.City.Mapper
{
    public static class CityMapper
    {

        public static TamTechSDK.Common.Services.ContentService.City.Models.CityDto MapToForntEndCity(this TamTechBackendSDK.ContentService.Services.Citis.Models.CityDto item)
        {
            return new TamTechSDK.Common.Services.ContentService.City.Models.CityDto
            {
                Id = item.Id,
                Name = item.Name,
                Published = item.Published,
                DisplayOrder = item.DisplayOrder
            };
        }
    }
}

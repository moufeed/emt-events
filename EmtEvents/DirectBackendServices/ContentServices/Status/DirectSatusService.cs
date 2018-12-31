using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamTechSDK.Common.Models.SelectList;
using TamTechSDK.Common.Services.ContentService.Status;

namespace EmtEvents.DirectBackendServices.ContentServices.Status
{
    public class DirectSatusService : IStatusService
    {
        private TamTechBackendSDK.ContentService.Services.Statuses.IStatusService _statusService;


        public DirectSatusService(TamTechBackendSDK.ContentService.Services.Statuses.IStatusService statusService)
        {
            _statusService = statusService;
        }


        public async Task<List<SelectListItemModel>> GetAllListAsync(string lang)
        {
            var result = await _statusService.GetAllListAsync(lang);

            return result != null ? result.Select(m => m.MapToFrontEndSelectListItemModel()).ToList() : new List<SelectListItemModel>();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmtEvents.DirectBackendServices.ContentServices.Content.Mapper;
using TamTechSDK.Common.Providers.Requests.Models;
using TamTechSDK.Common.Services.ContentService.ContentService.Models;
using TamTechSDK.Web.Services.Configurations.AppSetting;

namespace EmtEvents.DirectBackendServices.ContentServices.Content
{
    public class DirectContentService : TamTechSDK.Common.Services.ContentService.IContentServices
    {

        private readonly TamTechBackendSDK.ContentService.Services.Utilities.Content.IContentUtilities _contentUtilities;
        #region Ctors
        public DirectContentService(
                    TamTechBackendSDK.ContentService.Services.Utilities.Content.IContentUtilities contentUtilities)
        {

            _contentUtilities = contentUtilities;
        }
        #endregion


        public async Task<Dictionary<string, NumericalStatisticsDto>> GetNumericalStatisticsAsync(List<string> types, string lang)
        {
            var result = await _contentUtilities.GetNumericalStatisticsAsync(types, lang);

            var dec = result.Select(dict => dict).ToDictionary(m => m.Key, m => m.Value.MapToFrontEndNumericalStatisticsDto());
            return dec;


        }

        public async Task<IRequestProviderResult<List<KeyValuePair<Guid, string>>>> GetProductsNames()
        {
            return new RequestProviderResult<List<KeyValuePair<Guid, string>>>
            {
                Success = true,
                Data = new List<KeyValuePair<Guid, string>>
                 {
                     new KeyValuePair<Guid, string>( new Guid("c28fb34f-c10a-4bc5-847f-ddea4a181e82")  , "BlackBerry Keyone" ),
                     new KeyValuePair<Guid, string>( new Guid("5a7a1dd9-5421-418f-a481-0cb435274653")  , "Huawei Nova 3e" ),
                     new KeyValuePair<Guid, string>( new Guid("9a28a691-e437-4b8b-afff-fb92ea675bab")  , "Apple iPhone X" ),
                     new KeyValuePair<Guid, string>( new Guid("fa49fcc6-1f06-4552-924d-edeb404bc874")  , "LG Aurora Black" ),
                     new KeyValuePair<Guid, string>( new Guid("36ac42e5-d405-4cff-9943-6344bad809a3") , "LG V10" ),
                     new KeyValuePair<Guid, string>( new Guid("41dd4eb0-d263-4ebd-add4-d52bbcbf42f0") ,  "One Plus Dual Sim"),
                     new KeyValuePair<Guid, string>( new Guid("c2cd81cc-dd4c-4888-ad18-7138a0c970d3")  , "Samsung Galaxy S9" ),
                     new KeyValuePair<Guid, string>( new Guid("bfa509c3-5311-4952-b526-fbcc4a198467") , "Huawei Mate 9 Dual Sim - 64 GB, 4 GB RAM, 4G LTE , Mocha Brown" ),
                     new KeyValuePair<Guid, string>( new Guid("2799a6f5-3114-4ab0-a814-156989e17b0a")  , "Huawei P10 VTR-L29 Dual Sim - 64GB, 4GB RAM, 4G LTE, Dazzling Blue"  ),
                     new KeyValuePair<Guid, string>( new Guid("531f2a51-8d79-44cb-91e6-720b9798aaa6")  , "Samsung Galaxy S8+ Dual Sim - 64GB, 4G LTE, Midnight Black" ),
                     new KeyValuePair<Guid, string>( new Guid("657ec7ef-775f-46c2-a0bc-9fb8a2b141ab")  , "Samsung SL-M2070FW Xpress Mono Multifunction Laser Printer" ),
                     new KeyValuePair<Guid, string>( new Guid("c58d4458-2e2e-423d-9066-70c10e351b43")  , "Apple MacBook Pro With Touch Bar " ),
                 }
            };
        }

        public async Task<IRequestProviderResult<List<string>>> ProductHints()
        {
            return new RequestProviderResult<List<string>>
            {
                Success = true,
                Data = new List<string> {
                        "Brand","Operating System Type","Storage Capacity","Number Of SIM","Mobile Phone Type","Cellular Network Technology",
                        "CPU","Chipset manufacturer","Model Number","Battery Capacity in mAh","Rear Camera Resolution","Display Size",
                        "Front Camera","Operating System Version","Memory RAM",
                        "Alabama", "Alaska", "Arizona", "Arkansas", "California",
                        "Colorado", "Connecticut", "Delaware", "Florida", "Georgia", "Hawaii",
                        "Idaho", "Illinois", "Indiana", "Iowa", "Kansas", "Kentucky", "Louisiana",
                        "Maine", "Maryland", "Massachusetts", "Michigan", "Minnesota",
                        "Mississippi", "Missouri", "Montana", "Nebraska", "Nevada", "New Hampshire",
                        "New Jersey", "New Mexico", "New York", "North Carolina", "North Dakota",
                        "Ohio", "Oklahoma", "Oregon", "Pennsylvania", "Rhode Island",
                        "South Carolina", "South Dakota", "Tennessee", "Texas", "Utah", "Vermont",
                        "Virginia", "Washington", "West Virginia", "Wisconsin", "Wyoming"
            }
            };
        }
    }
}

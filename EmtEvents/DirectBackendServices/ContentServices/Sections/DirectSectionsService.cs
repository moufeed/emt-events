using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmtEvents.DirectBackendServices.ContentServices.Sections.Mapper;
using TamTechSDK.Common.Models.ContentItem;
using TamTechSDK.Common.Models.Pagination;
using TamTechSDK.Common.Models.Sort;
using TamTechSDK.Common.Providers.Requests.Models;
using TamTechSDK.Common.Services.ContentService.Posts.Models;
using TamTechSDK.Common.Services.ContentService.Sections;
using TamTechSDK.Common.Services.ContentService.Sections.Models;

namespace EmtEvents.DirectBackendServices.ContentServices.Sections
{
    public class DirectSectionsService : BaseDirectService, ISectionsService
    {
        #region Props  
        private readonly TamTechBackendSDK.ContentService.Services.Sections.ISectionService _SectionService;
        #endregion

        #region constructor
        public DirectSectionsService(TamTechBackendSDK.ContentService.Services.Sections.ISectionService SectionService)
        {
            _SectionService = SectionService;
        }
        #endregion


        #region public services


        public async Task<IRequestProviderResult<List<SectionDto>>> GetPublicListAsync()
        {
            var services = await _SectionService.GetPublicListAsync();
            List<SectionDto> SectionDto = services != null ? services.Select(m => m.MapToFrontendDto()).ToList() : new List<SectionDto>();
            return ReturnResult(SectionDto);
        }

        public async Task<List<SectionDto>> GetPublicLatestSectionsAsync()
        {
            var result = await _SectionService.GetPublicLatestSectionsAsync();
            List<SectionDto> sectionDto = result?.Select(m => m.MapToFrontendDto()).ToList();
            return sectionDto;
        }

        public async Task<SectionContainerDto> GetPublicSectionWithLatestSubSectionsBySlugAsync(string slug)
        {
            var result = await _SectionService.GetPublicSectionWithLatestSubSectionsBySlugAsync(slug);
            return result?.MapToContainerDto();
        }


        //public async Task<IRequestProviderResult<SectionDto>> GetPublicBySlugAsync(string slug)
        //{
        //    var service = await _SectionService.GetPublicBySlugAsync(slug);
        //    return ReturnResult(service.MapToFrontendDto());
        //}

        //public async Task<IRequestProviderResult<List<SectionDto>>> GetPublicListAsync(int takeitems)
        //{
        //    var services = await _SectionService.GetPublicListAsync(takeitems);
        //    List<SectionDto> SectionDto = services != null ? services.Select(m => m.MapToFrontendDto()).ToList() : new List<SectionDto>();
        //    return ReturnResult(SectionDto);
        //}

        //public async Task<IRequestProviderResult<SectionContainerDto>> GetPublicSectionContainerByParentSlugAsync(string slug)
        //{
        //    var result = await _SectionService.GetPublicSectionContainerByParentSlugAsync(slug);

        //    return ReturnResult(result.MapToContainerDto());
        //}






        #endregion

        #region manage sections

        public async Task<List<SectionDto>> GetAllAsync(string lang)
        {
            var result = await _SectionService.GetAllExceptSoftDeletedAsync(lang);
            List<SectionDto> sectionDto = result != null ? result.Select(m => m.MapToFrontendDto()).ToList() : new List<SectionDto>();
            return sectionDto;
        }

        public async Task<IRequestProviderResult<SectionList>> GetAllAsync(PaginationModel pagination, Dictionary<string, object> searchParams, SortingModel sorting, string lang)
        {

            var result = await _SectionService.GetAllExceptSoftDeletedAsync(pagination.MapToBackendPaginationModel(), searchParams, sorting.MapToBackendSortingModel(), lang);

            SectionList model = new SectionList
            {
                Data = result.Data != null ? result.Data.Select(m => m.MapToFrontendDto()).ToList() : new List<SectionDto>(),
                Pagination = result.Pagination?.MapToForntEndPagination()
            };

            return ReturnResult(model);
        }


        public async Task<IRequestProviderResult<Guid>> CreateAsync(CreateSectionDto model)
        {
            var result = await _SectionService.CreateAsync(model.MapTobackendCreateSection());
            return MapRequestProviderResult(result);
        }

        public async Task<IRequestProviderResult<bool>> EditAsync(UpdateSectionDto model)
        {
            var result = await _SectionService.EditAsync(model.MapToBackendDto());
            return MapRequestProviderResult(result);
        }

        public async Task<IRequestProviderResult<SectionDto>> GetByIdAsync(Guid id, string lang)
        {
            var result = await _SectionService.GetByIdExceptSoftDeletedAsync(id, lang);
            return ReturnResult(result.MapToFrontendDto());
        }

        public async Task<IRequestProviderResult<bool>> PublishAsync(PublishDTO data)
        {
            var result = await _SectionService.PublishAsync(data.MapToBackend());
            return MapRequestProviderResult(result);
        }

        public async Task<IRequestProviderResult<bool>> DeleteAsync(Guid id)
        {
            var result = await _SectionService.SoftDeleteAsync(id);
            return MapRequestProviderResult(result);
        }



        #endregion
    }
}

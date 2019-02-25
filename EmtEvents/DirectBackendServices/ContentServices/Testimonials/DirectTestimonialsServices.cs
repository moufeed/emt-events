using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamTechSDK.Common.Models.ContentItem;
using TamTechSDK.Common.Models.Pagination;
using TamTechSDK.Common.Models.Sort;
using TamTechSDK.Common.Providers.Requests.Models;
using TamTechSDK.Common.Services.ContentService.Testimonials;
using TamTechSDK.Common.Services.ContentService.Testimonials.Models;
using TamTechBackendSDK.ContentService.Services.Testimonials;
using EmtEvents.DirectBackendServices.ContentServices.Testimonials.Mapper;

namespace EmtEvents.DirectBackendServices.ContentServices.Testimonials
{
    public class DirectTestimonialsServices : BaseDirectService , ITestimonialsServices 
    {
        private ITestimonialService _testimonialsServices;


        public DirectTestimonialsServices(ITestimonialService testimonialsServices)
        {
            _testimonialsServices = testimonialsServices;
        }

        public async Task<IRequestProviderResult<List<TestimonialDto>>> GetPublicListAsync(bool sortManually = false)
        {
            var Testimonial = await _testimonialsServices.GetPublicListAsync(sortManually);
            List<TestimonialDto> TestimonialDto = Testimonial?.Select(m => m.MapToFrontendDto()).ToList();
            return ReturnResult(TestimonialDto , (Testimonial !=null ));

        }

        public async Task<IRequestProviderResult<TestimonialsList>> GetAllAsync(PaginationModel pagination, Dictionary<string, object> searchParams, SortingModel sorting, string lang)
        {
            var result = await _testimonialsServices.GetAllExceptSoftDeletedAsync(pagination.MapToBackendPaginationModel(), searchParams, sorting.MapToBackendSortingModel(), lang);

            TestimonialsList model = new TestimonialsList
            {
                Data = result.Data != null ? result.Data.Select(m => m.MapToFrontendDto()).ToList() : new List<TestimonialDto>(),
                Pagination = result.Pagination?.MapToForntEndPagination()
            };

            return ReturnResult(model);

        }

        public async Task<IRequestProviderResult<Guid>> CreateAsync(CreateTestimonialDto model)
        {
            var result = await _testimonialsServices.CreateAsync(model.MapToBackendDto());
            return MapRequestProviderResult(result);
             
        }

        public async Task<IRequestProviderResult<TestimonialDto>> GetByIdAsync(Guid id, string lang)
        {
            var testimonial = await _testimonialsServices.GetByIdExceptSoftDeletedAsync(id, lang);
            return ReturnResult(testimonial?.MapToFrontendDto() , testimonial != null );
 
        }

        public async Task<IRequestProviderResult<bool>> EditAsync(UpdateTestimonialDto model)
        {
            var result = await _testimonialsServices.EditAsync(model.MapToBackendUpdateDto());
            return MapRequestProviderResult(result);
        }

        public async Task<IRequestProviderResult<bool>> DeleteAsync(Guid id)
        {
            var result = await _testimonialsServices.SoftDeleteAsync(id);
            return MapRequestProviderResult(result);
        }

        public async Task<IRequestProviderResult<bool>> PublishAsync(PublishDTO data)
        {
            var result = await _testimonialsServices.PublishAsync(data.MapToBackend());
            return MapRequestProviderResult(result);

        }
    }
}

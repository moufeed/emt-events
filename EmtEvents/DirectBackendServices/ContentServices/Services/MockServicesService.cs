using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamTechSDK.Common.Providers.Requests.Models;
using TamTechSDK.Common.Services.ContentService.Services.Models;

namespace EmtEvents.DirectBackendServices.ContentServices.Services
{
    public class MockServicesService // : TamTechSDK.Common.Services.ContentService.Services.IServicesService
    {
        public async Task<IRequestProviderResult<Guid>> CreateAsync(CreateServiceDto Service)
        {
            return new RequestProviderResult<Guid>
            {
                Success = true,
                // Data = true
            };
        }

        public async Task<IRequestProviderResult<bool>> EditAsync(UpdateServiceDto model)
        {
            return new RequestProviderResult<bool>
            {
                Success = true,
                Data = true
            };
        }

        public async Task<IRequestProviderResult<bool>> DeleteAsync(Guid id)
        {
            return new RequestProviderResult<bool>
            {
                Success = true,
                Data = true
            };
        }

        public async Task<IRequestProviderResult<bool>> PublishAsync(Guid id)
        {
            return new RequestProviderResult<bool>
            {
                Success = true,
                Data = true
            };
        }


        public async Task<IRequestProviderResult<List<ServiceDto>>> GetAllAsync()
        {

            return new RequestProviderResult<List<ServiceDto>>
            {
                Success = true,
                Data = new List<ServiceDto>
                {
                    new ServiceDto {
                        Id = new Guid("23541438-1eec-45b0-96b4-97d447f86d2e"),
                        Title = "Mobile Apps",
                        Slug ="mobile_apps",
                        MainImage ="http://via.placeholder.com/150x150",
                        Summary = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the",
                        CreatedDate = DateTime.Now,
                        DisplayOrder = 2,
                        Content = "Lorem Ipsum is simply dummy text of the printing and typesetting industry.",
                    },
                    new ServiceDto {
                        Id = new Guid("4d657f36-9ca3-4520-879c-64eea6947ad7"),
                        Title = "Creative Websites",
                        Slug ="creative_websites",
                        MainImage ="http://via.placeholder.com/150x150",
                        Summary = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's ",
                        CreatedDate = DateTime.Now,
                        DisplayOrder = 3,
                        Content = "Lorem Ipsum is simply dummy text of the printing and typesetting industry.",

                    },
                    new ServiceDto {
                        Id = new Guid("2688b521-760d-4e95-a879-89db1c009cc8"),
                        Title = "SEO Optimization",
                        Slug ="seo_optimzation",
                        MainImage ="http://via.placeholder.com/150x150",
                        Summary = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley ",
                        CreatedDate = DateTime.Now,
                        DisplayOrder = 0,
                        Content = "Lorem Ipsum is simply dummy text of the printing and typesetting industry.",

                    } ,
                    new ServiceDto {
                        Id = new Guid("3fd2b6e4-8585-4fe2-b81d-b41e1da25d29"),
                        Title = "SEO Optimization",
                        Slug ="seo_optimzation",
                        MainImage ="http://via.placeholder.com/150x150",
                        Summary = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley ",
                        CreatedDate = DateTime.Now,
                        DisplayOrder = 0,
                        Content = "Lorem Ipsum is simply dummy text of the printing and typesetting industry.",

                    }
                }
            };
        }

        public async Task<IRequestProviderResult<ServiceDto>> GetByIdAsync(Guid id, string lang)
        {
            return new RequestProviderResult<ServiceDto>
            {
                Success = true,
                Data = new ServiceDto
                {
                    Id = new Guid("ff18d7f1-6e01-44e5-98c4-f983ddb3be42"),
                    Title = "Creative Websites",
                    Slug = "creative_websites",
                    MainImage = "http://via.placeholder.com/150x150",
                    Summary = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's ",
                    CreatedDate = DateTime.Now,
                    DisplayOrder = 3,
                    Content = "Lorem Ipsum is simply dummy text of the printing and typesetting industry.",

                }
            };
        }
    }
}

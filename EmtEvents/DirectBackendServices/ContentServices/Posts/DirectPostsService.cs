using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamTechSDK.Common.Models.ContentItem;
using TamTechSDK.Common.Providers.Requests.Models;
using TamTechSDK.Common.Services.ContentService.Posts.Models;
using EmtEvents.DirectBackendServices.ContentServices.Posts.Mapper;
using TamTechSDK.Common.Models.Pagination;
using TamTechSDK.Common.Models.Sort;

namespace EmtEvents.DirectBackendServices.ContentServices.Posts
{
    public class DirectPostsService : BaseDirectService, TamTechSDK.Common.Services.ContentService.Posts.IPostsService
    {
        private readonly TamTechBackendSDK.ContentService.Services.Posts.IPostService _postService;


        public DirectPostsService(TamTechBackendSDK.ContentService.Services.Posts.IPostService postService)
        {
            _postService = postService;
        }



        #region {Services Manager}  
        public async Task<IRequestProviderResult<PostsList>> GetAllAsync(PaginationModel pagination, Dictionary<string, object> searchParams, SortingModel sorting, string lang)
        {

            var result = await _postService.GetAllExceptSoftDeletedAsync(pagination.MapToBackendPaginationModel(), searchParams, sorting.MapToBackendSortingModel(), lang);



            PostsList model = new PostsList
            {
                Data = result.Data?.Select(m => m.MapToFrontendDto()).ToList(),
                Pagination = result.Pagination?.MapToForntEndPagination()
            };

            return ReturnResult(model);

        }


        public async Task<IRequestProviderResult<Guid>> CreateAsync(CreatePostDto model)
        {
            var result = await _postService.CreateAsync(model.MapToBackendDto());
            return MapRequestProviderResult(result);
        }


        public async Task<IRequestProviderResult<PostDto>> GetByIdAsync(Guid id, string lang)
        {
            var post = await _postService.GetByIdExceptSoftDeletedAsync(id, lang);
            return ReturnResult(post.MapToFrontendDto());
        }

        public async Task<IRequestProviderResult<bool>> EditAsync(UpdatePostDto model)
        {
            var result = await _postService.EditAsync(model.MapToBackendDto());
            return MapRequestProviderResult(result);
        }

        public async Task<IRequestProviderResult<bool>> PublishAsync(PublishDTO data)
        {
            var result = await _postService.PublishAsync(data.MapToBackend());
            return MapRequestProviderResult(result);
        }

        public async Task<IRequestProviderResult<bool>> DeleteAsync(Guid id)
        {
            var result = await _postService.SoftDeleteAsync(id);
            return MapRequestProviderResult(result);
        }

        #endregion


        #region {Public Services}  


        //public async Task<IRequestProviderResult<PostDto>> GetPublicBySlugAsync(string slug)
        //{
        //    var service = await _postService.GetPublicBySlugAsync(slug);
        //    return ReturnResult(service.MapToPublicFrontendDto());
        //}

        //public async Task<IRequestProviderResult<List<PostDto>>> GetPublicListAsync()
        //{
        //    var posts = await _postService.GetPublicListAsync();
        //    List<PostDto> servicesDto = posts != null ? posts.Select(m => m.MapToFrontendDto()).ToList() : new List<PostDto>();
        //    return ReturnResult(servicesDto);
        //}

        //public async Task<IRequestProviderResult<List<PostDto>>> GetPublicListAsync(int takeitems)
        //{
        //    var posts = await _postService.GetPublicListAsync(takeitems);
        //    List<PostDto> servicesDto = posts != null ? posts.Select(m => m.MapToFrontendDto()).ToList() : new List<PostDto>();
        //    return ReturnResult(servicesDto);
        //}

        public async Task<PostsList> GetPublicLatestPostsAsync(PaginationModel Pagination)
        {
            var result = await _postService.GetPublicLatestPostsAsync(Pagination.toBackendPaginationModel(),6);
            PostsList model = new PostsList
            {
                Data = result.Data?.Select(m => m.MapToFrontendDto()).ToList(),
                Pagination = result.Pagination?.MapToForntEndPagination()
            };

            return model;
        }
        public async Task<PostsList> GetPublicLatestPostsBySectionSlugAsync(PaginationModel Pagination, string sectionSlug)
        {

            var result = await _postService.GetPublicLatestPostsBySectionSlugAsync(Pagination.toBackendPaginationModel(), sectionSlug  );

            PostsList model = new PostsList
            {
                Data = result.Data?.Select(m => m.MapToFrontendDto()).ToList(),
                Pagination = result.Pagination?.MapToForntEndPagination()
            };

            return model;

        }

        public async Task<PostDto> GetPublicBySlugAndSectionSlugsAsync(List<string> sectionSlugs, string slug)
        {
            var post = await _postService.GetPublicBySlugAndSectionSlugsAsync(sectionSlugs, slug);
            return post.MapToPublicFrontendDto();
        }

        public async Task<List<PostDto>> GetPublicListAsync(int takeItems)
        {
            var result = await _postService.GetPublicListAsync(takeItems);
            var posts = new List<PostDto>();
            if (result != null)
            {
                posts = result.Select(m => m.MapToFrontendDto()).ToList();
            }
            return posts;
        }

        public async Task<PostsList> GetPublicListAsync(PaginationModel pagination)
        {
            var result = await _postService.GetPublicListAsync(pagination.toBackendPaginationModel());

            var posts = new PostsList();
            if (result != null)
            {
                posts.Data = result.Data != null ? result.Data.Select(m => m.MapToFrontendDto()).ToList() : new List<PostDto>();
                posts.Pagination = result.Pagination != null ? result.Pagination.MapToForntEndPagination() : new PaginationMetadataModel();

            }
            return posts;
        }

        public async Task<PostsList> GetPublicListBySectionSlugAsync(PaginationModel pagination, string slugHierarchy)
        {
            var result = await _postService.GetPublicListBySectionSlugAsync(pagination.toBackendPaginationModel(), slugHierarchy);

            var model = new PostsList();
            if (result != null)
            {
                model.Data = result.Data != null ? result.Data.Select(m => m.MapToFrontendDto()).ToList() : new List<PostDto>();
                model.Pagination = result.Pagination != null ? result.Pagination.MapToForntEndPagination() : new PaginationMetadataModel();

            }

            return model;
        }
        #endregion

    }
}

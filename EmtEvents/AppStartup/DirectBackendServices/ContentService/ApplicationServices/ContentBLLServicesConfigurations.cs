using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TamTechBackendSDK.ContentService.Helpers;
using TamTechBackendSDK.ContentService.Services;
using TamTechBackendSDK.ContentService.Services.Brands;
using TamTechBackendSDK.ContentService.Services.Categorys;
using TamTechBackendSDK.ContentService.Services.Cities;
using TamTechBackendSDK.ContentService.Services.Galleries;
using TamTechBackendSDK.ContentService.Services.Menus;
using TamTechBackendSDK.ContentService.Services.Pages;
using TamTechBackendSDK.ContentService.Services.Posts;
using TamTechBackendSDK.ContentService.Services.ProductCatalog;
using TamTechBackendSDK.ContentService.Services.Products;
using TamTechBackendSDK.ContentService.Services.Requests;
using TamTechBackendSDK.ContentService.Services.Sections;
using TamTechBackendSDK.ContentService.Services.Services;
using TamTechBackendSDK.ContentService.Services.Shared;
using TamTechBackendSDK.ContentService.Services.Sliders;
using TamTechBackendSDK.ContentService.Services.Statuses;
using TamTechBackendSDK.ContentService.Services.Utilities.Content;

namespace EmtEvents.AppStartup.DirectBackendServices.ContentService.ApplicationServices
{
    public static class ContentBLLServicesConfigurations
    {
        public static void DirectBackendServices_ContentService_AddContentBLLServicesConfigurations(this IServiceCollection services)
        {
            services.AddScoped<IIdentityHelper, HttpContextHelper>();


            services.AddTransient<IContentUtilities, ContentUtilities>();
            services.AddTransient<PageServiceManager, PageServiceManager>();
            services.AddTransient<IPageService, PageService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IBrandService, BrandService>();
            services.AddTransient<MenuServiceManager, MenuServiceManager>();
            services.AddTransient<IMenuService, MenuService>();
            services.AddTransient<ServicesServiceManager, ServicesServiceManager>();
            services.AddTransient<IServicesModuleService, ServicesModuleService>();
            services.AddTransient<ISliderService, SliderService>();
            services.AddTransient<GalleryServiceManager, GalleryServiceManager>();
            services.AddTransient<IGalleryService, GalleryService>();

            services.AddTransient<ISectionService, SectionService>();
            services.AddTransient<IPostService, PostService>();

            services.AddTransient<IRequestService, RequestService>();
            services.AddTransient<ICityService, CityService>();
            services.AddTransient<IStatusService, StatusService>();



            services.AddTransient<IPagesService, PagesService>();
            services.AddTransient<IProductCatalogService, ProductCatalogService>();
            services.AddTransient<IContentsService, ContentsService>();
        }
    }
}

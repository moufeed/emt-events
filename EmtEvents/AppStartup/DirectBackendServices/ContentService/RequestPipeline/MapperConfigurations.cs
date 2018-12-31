using AutoMapper;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;
using TamTechBackendSDK.ContentService.Models.Pages;
using TamTechBackendSDK.ContentService.Models.Products;
using TamTechBackendSDK.ContentService.Models.Settings;
using TamTechBackendSDK.ContentService.Repositories.DB;
using TamTechBackendSDK.ContentService.Services.Pages.Dtos;

namespace EmtEvents.AppStartup.DirectBackendServices.ContentService.RequestPipeline
{
    public static class MapperConfigurations
    {
        public static void ContentService_InitializeMapper(this IMapperConfigurationExpression cfg)
        {

            //cfg.CreateMap<CreateHtmlPageDto, HtmlPage>();
            //// .ForMember(dest => dest.HtmlContent, y => y.MapFrom(src => src.Content));
            //cfg.CreateMap<CreateSectionsPageDto, SectionsPage>();
            //// .ForMember(dest => dest.SectionsContent, y => y.MapFrom(src => src.Content));
            //cfg.CreateMap<UpdateHtmlPageDto, HtmlPage>();
            ////.ForMember(dest => dest.HtmlContent, y => y.MapFrom(src => src.Content));
            //cfg.CreateMap<UpdateSectionsPageDto, SectionsPage>();
            //  .ForMember(dest => dest.SectionsContent, y => y.MapFrom(src => src.Content));
            cfg.CreateMap<HtmlPage, HtmlPageDto>();
            //    .ForMember(dest => dest.Content, y => y.MapFrom(src => src.HtmlContent));
            cfg.CreateMap<SectionsPage, SectionsPageDto>();
            //  .ForMember(dest => dest.Content, y => y.MapFrom(src => src.SectionsContent));
            cfg.CreateMap<Page, PageDto>();


            cfg.CreateMap<BasicPage, BasicPageDTO>();
            cfg.CreateMap<BasicPageDTO, BasicPage>();

            cfg.CreateMap<Category, Guid>().ConvertUsing(src => src.Id);

            cfg.CreateMap<Product, ProductDTO>()
                .ForMember(dest => dest.CategoryIds, y => y.MapFrom(src => src.Categories));
            cfg.CreateMap<ProductDTO, Product>();


            cfg.CreateMap<Brand, BrandDTO>()
                .ForMember(dest => dest.CategoryIds, y => y.MapFrom(src => src.Categories));
            cfg.CreateMap<BrandDTO, Brand>();


            cfg.CreateMap<LookupKeyValueBase, LookupKeyValueBaseDTO>();
            cfg.CreateMap<LookupKeyValueBaseDTO, LookupKeyValueBase>();

            cfg.CreateMap<FavoriteItem, FavoriteItemDTO>();
            cfg.CreateMap<FavoriteItemDTO, FavoriteItem>();




        }
    }
}

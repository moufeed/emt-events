using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmtEvents.DirectBackendServices.ContentServices.Pages.Mapper
{
    public static class PageMapper
    {


        public static TamTechSDK.Common.Services.ContentService.Pages.Models.PageDto MapToFrontendDto(this TamTechBackendSDK.ContentService.Services.Pages.Dtos.PageDto backend)
        {
            return new TamTechSDK.Common.Services.ContentService.Pages.Models.PageDto
            {

                Lang = backend.Lang,
                Id = backend.Id,
                Title = backend.Title,
                Slug = backend.Slug,
                Keywords = backend.Keywords,
                Section = backend.Section,
                MainImage = backend.MainImage,
                Summary = backend.Summary,
                Type = backend.Type,
                Published = backend.Published,
                ClientId = backend.ClientId,
                CreatorUserId = backend.CreatorUserId,
                ModifierUserId = backend.ModifierUserId,
                DisplayOrder = backend.DisplayOrder,
                ModifiedDate = backend.ModifiedDate,
                CreatedDate = backend.CreatedDate,
                Tags = backend.Tags,
                MetaDescription = backend.MetaDescription,
                Locked = backend.Locked,
                AuthorName = backend.AuthorName,
                PublishedDate = backend.PublishedDate,
                SEOMarkup = backend.SEOMarkup,
            };
        }


        public static TamTechSDK.Common.Services.ContentService.Pages.Models.PageSummary MapToPageSummaryFrontend(this TamTechBackendSDK.ContentService.Services.Pages.Dtos.PageDto backend)
        {
            return new TamTechSDK.Common.Services.ContentService.Pages.Models.PageSummary
            {
                Id = backend.Id.ToString(),
                Title = backend.Title,
                Slug = backend.Slug,
                Section = backend.Section,
                MainImage = backend.MainImage,
                Summary = backend.Summary,
                ModifiedDate = backend.ModifiedDate,
                CreatedDate = backend.CreatedDate,


            };
        }
        public static TamTechSDK.Common.Services.ContentService.Pages.Models.HtmlPage MapToFrontendDto(this TamTechBackendSDK.ContentService.Services.Pages.Dtos.HtmlPageDto backend)
        {
            return new TamTechSDK.Common.Services.ContentService.Pages.Models.HtmlPage
            {

                Lang = backend.Lang,
                Id = backend.Id,
                Title = backend.Title,
                Slug = backend.Slug,
                Content = backend.Content,
                Keywords = backend.Keywords,
                Section = backend.Section,
                MainImage = backend.MainImage,
                Summary = backend.Summary,
                Type = backend.Type,
                Published = backend.Published,
                ClientId = backend.ClientId,
                CreatorUserId = backend.CreatorUserId,
                ModifierUserId = backend.ModifierUserId,
                DisplayOrder = backend.DisplayOrder,
                ModifiedDate = backend.ModifiedDate,
                CreatedDate = backend.CreatedDate,
                Tags = backend.Tags,
                MetaDescription = backend.MetaDescription,
                SEOMarkup = backend.SEOMarkup,
                Locked = backend.Locked,
                AuthorName = backend.AuthorName,
                PublishedDate = backend.PublishedDate
            };
        }

        public static TamTechSDK.Common.Services.ContentService.Pages.Models.SectionsPage MapToFrontendDto(this TamTechBackendSDK.ContentService.Services.Pages.Dtos.SectionsPageDto backend)
        {
            return new TamTechSDK.Common.Services.ContentService.Pages.Models.SectionsPage
            {
                Lang = backend.Lang,
                Id = backend.Id,
                Title = backend.Title,
                Slug = backend.Slug,
                Content = backend.Content,
                Keywords = backend.Keywords,
                Section = backend.Section,
                MainImage = backend.MainImage,
                Summary = backend.Summary,
                Type = backend.Type,
                Published = backend.Published,
                ClientId = backend.ClientId,
                CreatorUserId = backend.CreatorUserId,
                ModifierUserId = backend.ModifierUserId,
                DisplayOrder = backend.DisplayOrder,
                ModifiedDate = backend.ModifiedDate,
                CreatedDate = backend.CreatedDate,
                Tags = backend.Tags,
                MetaDescription = backend.MetaDescription,
                SEOMarkup = backend.SEOMarkup,
                Locked = backend.Locked,
                ContentPublishDate = backend.ContentPublishDate,
                PublishedDate = backend.PublishedDate,
                AuthorName = backend.AuthorName
            };
        }
        //public static TamTechBackendSDK.ContentService.Pages.Dtos.CreateHtmlPageDto MapToModel(this TamTechSDK.Common.Services.ContentService.Pages.Models.HtmlPageCreationDto common)
        //{
        //    return new TamTechBackendSDK.ContentService.Dtos.Pages.HtmlPageCreationDto
        //    {
        //        Title = common.Title,
        //        Slug = common.Slug,
        //        Content = common.Content,
        //        Keywords = common.Keywords,
        //        Section = common.Section,
        //        MainImage = common.MainImage,
        //        Summary = common.Summary
        //    };
        //}
        //public static TamTechBackendSDK.ContentService.Dtos.Pages.SectionsPageUpdatingDto USPVMToDto(this TamTechSDK.Common.Services.ContentService.Pages.Models.SectionsPageEditingDto vm)
        //{
        //    return new TamTechBackendSDK.ContentService.Dtos.Pages.SectionsPageUpdatingDto
        //    {
        //        Id= vm.Id.ToString(),
        //        Title = vm.Title,
        //        Slug = vm.Slug,
        //        Content = vm.Content,
        //        Keywords = vm.Keywords,
        //        Section = vm.Section,
        //        MainImage = vm.MainImage,
        //        Summary = vm.Summary
        //    };
        //}
        //public static TamTechBackendSDK.ContentService.Dtos.Pages.HtmlPageUpdatingDto UHPVMToDto(this TamTechSDK.Common.Services.ContentService.Pages.Models.HtmlPageEditingDto vm)
        //{
        //    return new TamTechBackendSDK.ContentService.Dtos.Pages.HtmlPageUpdatingDto
        //    {
        //        Id= vm.Id.ToString(),
        //        Title = vm.Title,
        //        Slug = vm.Slug,
        //        Content = vm.Content,
        //        Keywords = vm.Keywords,
        //        Section = vm.Section,
        //        MainImage = vm.MainImage,
        //        Summary = vm.Summary
        //    };
        //}





        public static TamTechBackendSDK.ContentService.Services.Pages.Dtos.UpdatePageDto MapToBackendDto(this TamTechSDK.Common.Services.ContentService.Pages.Models.EditHtmlPageDto frontend)
        {
            return new TamTechBackendSDK.ContentService.Services.Pages.Dtos.UpdatePageDto
            {
                Lang = frontend.Lang,
                Id = frontend.Id,
                Title = frontend.Title,
                Slug = frontend.Slug,
                Summary = frontend.Summary,
                MainImage = frontend.MainImage,
                Section = frontend.Section,
                Keywords = frontend.Keywords,
                HtmlContent = frontend.Content,
                DisplayOrder = frontend.DisplayOrder,
                MetaDescription = frontend.MetaDescription,
                Type = (int)TamTechBackendSDK.ContentService.Services.Pages.Enums.PageTypeEnum.Html,
                SEOMarkup = frontend.SEOMarkup,
                AuthorName = frontend.AuthorName,

            };
        }


        public static TamTechBackendSDK.ContentService.Services.Pages.Dtos.UpdatePageDto MapToBackendDto(this TamTechSDK.Common.Services.ContentService.Pages.Models.EditSectionsPageDto frontend)
        {
            return new TamTechBackendSDK.ContentService.Services.Pages.Dtos.UpdatePageDto
            {
                Lang = frontend.Lang,
                Id = frontend.Id,
                Title = frontend.Title,
                Slug = frontend.Slug,
                Summary = frontend.Summary,
                MainImage = frontend.MainImage,
                Section = frontend.Section,
                Keywords = frontend.Keywords,
                SectionsContent = frontend.Content,
                DisplayOrder = frontend.DisplayOrder,
                MetaDescription = frontend.MetaDescription,
                Type = (int)TamTechBackendSDK.ContentService.Services.Pages.Enums.PageTypeEnum.Sections,
                SEOMarkup = frontend.SEOMarkup,
                AuthorName = frontend.AuthorName
            };
        }






        public static TamTechBackendSDK.ContentService.Services.Pages.Dtos.CreatePageDto MapToBackendDto(this TamTechSDK.Common.Services.ContentService.Pages.Models.CreateHtmlPageDto frontend)
        {
            return new TamTechBackendSDK.ContentService.Services.Pages.Dtos.CreatePageDto
            {
                Lang = frontend.Lang,
                Title = frontend.Title,
                Slug = frontend.Slug,
                Summary = frontend.Summary,
                MainImage = frontend.MainImage,
                Section = frontend.Section,
                Keywords = frontend.Keywords,
                HtmlContent = frontend.Content,
                DisplayOrder = frontend.DisplayOrder,
                MetaDescription = frontend.MetaDescription,
                Type = (int)TamTechBackendSDK.ContentService.Services.Pages.Enums.PageTypeEnum.Html,
                AuthorName = frontend.AuthorName,
                SEOMarkup = frontend.SEOMarkup
            };
        }


        public static TamTechBackendSDK.ContentService.Services.Pages.Dtos.CreatePageDto MapToBackendDto(this TamTechSDK.Common.Services.ContentService.Pages.Models.CreateSectionsPageDto frontend)
        {
            return new TamTechBackendSDK.ContentService.Services.Pages.Dtos.CreatePageDto
            {
                Lang = frontend.Lang,
                Title = frontend.Title,
                Slug = frontend.Slug,
                Summary = frontend.Summary,
                MainImage = frontend.MainImage,
                Section = frontend.Section,
                Keywords = frontend.Keywords,
                SectionsContent = frontend.Content,
                DisplayOrder = frontend.DisplayOrder,
                MetaDescription = frontend.MetaDescription,
                Type = (int)TamTechBackendSDK.ContentService.Services.Pages.Enums.PageTypeEnum.Sections,
                AuthorName = frontend.AuthorName,
            };
        }


    }
}


//


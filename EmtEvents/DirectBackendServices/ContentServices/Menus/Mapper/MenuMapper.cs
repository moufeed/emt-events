using System.Collections.Generic;
using System.Linq;

namespace EmtEvents.DirectBackendServices.ContentServices.Menus.Mapper
{
    public static class MenuMapper
    {
        public static TamTechBackendSDK.ContentService.Services.Menus.Dtos.CreateMenuModel MapToBackendDto(this TamTechSDK.Common.Services.ContentService.Menus.Models.CreateMenuDto frontend)
        {
            return new TamTechBackendSDK.ContentService.Services.Menus.Dtos.CreateMenuModel
            {
                Position = frontend.Position,
                Key = frontend.Key,
                Title = frontend.Title,
                Lang = frontend.Lang,
            };
        }

        public static TamTechBackendSDK.ContentService.Services.Menus.Dtos.CreateMenuItemModel MapToBackendDto(this TamTechSDK.Common.Services.ContentService.Menus.Models.CreateMenuItemDto frontend)
        {
            return new TamTechBackendSDK.ContentService.Services.Menus.Dtos.CreateMenuItemModel
            {
                RootMenuId = frontend.MenuId,
                ParentKey = frontend.ParentKey,
                ItemType = frontend.ItemType,
                Title = frontend.Title,
                DisplayOrder = frontend.DisplayOrder,
                Url = frontend.Url,
                UrlTarget = frontend.UrlTarget,
                Lang = frontend.Lang,

            };
        }

        public static TamTechBackendSDK.ContentService.Services.Menus.Dtos.MenuItemKeysModel MapToBackendDto(this TamTechSDK.Common.Services.ContentService.Menus.Models.MenuItemKeysDto frontend)
        {
            return new TamTechBackendSDK.ContentService.Services.Menus.Dtos.MenuItemKeysModel
            {
                RootMenuId = frontend.RootMenuId,
                Key = frontend.Key,
            };
        }

        public static TamTechBackendSDK.ContentService.Services.Menus.Dtos.PublishMenuItemDto MapToBackendPublishDto(this TamTechSDK.Common.Services.ContentService.Menus.Models.MenuItemKeysDto frontend)
        {
            return new TamTechBackendSDK.ContentService.Services.Menus.Dtos.PublishMenuItemDto
            {
                RootMenuId = frontend.RootMenuId,
                Key = frontend.Key,
                Lang = frontend.Lang
            };
        }


        public static TamTechBackendSDK.ContentService.Services.Menus.Dtos.UpdateMenuModel MapToBackendDto(this TamTechSDK.Common.Services.ContentService.Menus.Models.UpdateMenuDto frontend)
        {
            return new TamTechBackendSDK.ContentService.Services.Menus.Dtos.UpdateMenuModel
            {
                Id = frontend.Id,
                Position = frontend.Position,
                Title = frontend.Title,
                Lang = frontend.Lang,
                Key = frontend.Key
            };
        }


        public static TamTechBackendSDK.ContentService.Services.Menus.Dtos.UpdateMenuItemModel MapToBackendDto(this TamTechSDK.Common.Services.ContentService.Menus.Models.UpdateMenuItemDto frontend)
        {
            return new TamTechBackendSDK.ContentService.Services.Menus.Dtos.UpdateMenuItemModel
            {
                DisplayOrder = frontend.DisplayOrder,
                ItemType = frontend.ItemType,
                RootMenuId = frontend.RootMenuId,
                Key = frontend.Key,
                Title = frontend.Title,
                Url = frontend.Url,
                UrlTarget = frontend.UrlTarget,
                Lang = frontend.Lang,
            };
        }



        public static TamTechSDK.Common.Services.ContentService.Menus.Models.MenuLiteDto MapToFrontendLiteDto(this TamTechBackendSDK.ContentService.Services.Menus.Dtos.MenuDto backend)
        {
            return new TamTechSDK.Common.Services.ContentService.Menus.Models.MenuLiteDto
            {
                Id = backend.Id,
                Key = backend.Key,
                Title = backend.Title,
                Position = backend.Position,
                CreatedDate = backend.CreatedDate,
                ModifiedDate = backend.ModifiedDate,
                Lang = backend.Lang,
                Locked = backend.Locked
            };
        }

        public static TamTechSDK.Common.Services.ContentService.Menus.Models.MenuItemDto MapToFrontendDto(this TamTechBackendSDK.ContentService.Services.Menus.Dtos.MenuItemDto backend)
        {
            return new TamTechSDK.Common.Services.ContentService.Menus.Models.MenuItemDto
            {

                Key = backend.Key,
                Title = backend.Title,
                DisplayOrder = backend.DisplayOrder,
                ItemType = backend.ItemType,
                MenuItems = backend.MenuItems != null ? backend.MenuItems.Select(m => m.MapToFrontendDto()).ToList() : new List<TamTechSDK.Common.Services.ContentService.Menus.Models.MenuItemDto>(),
                Published = backend.Published,
                Url = backend.Url,
                UrlTarget = backend.UrlTarget,
                Lang = backend.Lang,
            };
        }



        public static TamTechSDK.Common.Services.ContentService.Menus.Models.MenuDto MapToFrontendDto(this TamTechBackendSDK.ContentService.Services.Menus.Dtos.MenuDto backend)
        {
            return new TamTechSDK.Common.Services.ContentService.Menus.Models.MenuDto
            {
                Id = backend.Id,
                Key = backend.Key,
                Title = backend.Title,
                Position = backend.Position,
                Locked = backend.Locked,
                CreatedDate = backend.CreatedDate,
                ModifiedDate = backend.ModifiedDate,
                MenuItems = backend.MenuItems != null ? backend.MenuItems.Select(m => m.MapToFrontendDto()).ToList() : new List<TamTechSDK.Common.Services.ContentService.Menus.Models.MenuItemDto>(),
                Lang = backend.Lang,
            };
        }





    }
}

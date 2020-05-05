using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TamTechSDK.Common.Services.ContentService.Menus;
using TamTechSDK.Common.Services.ContentService.Menus.Enums;
using TamTechSDK.Common.Services.ContentService.Menus.Models;

namespace EmtEvents.TagHelpers
{
    [HtmlTargetElement("navbar")]
    public class Menu : TagHelper
    {
        private readonly IPublicMenusService _publicMenusService;

        private Dictionary<string, string> paths;

        public Menu(IPublicMenusService publicMenusService)
        {
            _publicMenusService = publicMenusService;

            var culture = CultureInfo.CurrentCulture.Name;
            paths = new Dictionary<string, string>
                   {
                      { MenuItemTypeEnum.product.ToString()  , $"/{culture}/portal/products/Details" },
                      { MenuItemTypeEnum.page.ToString()  , $"/{culture}/portal/pages/v" },
                      { MenuItemTypeEnum.staticpage.ToString()  , $"/{culture}/portal" },
                      { MenuItemTypeEnum.service.ToString()  , $"/{culture}/portal/services/v" },
                      { MenuItemTypeEnum.section.ToString()  , $"/{culture}/portal/posts/s" },
                      { MenuItemTypeEnum.gallery.ToString()  , $"/{culture}/portal/galleries/v" },
                      { MenuItemTypeEnum.section_of_service.ToString()  , $"/{culture}/portal/services/s" },
                   };
        }



        private string PrintNav(List<MenuItemDto> MenuItems)
        {
            string nav = $"<nav class=\"top-nav\">";
            
            nav += Print_UL(MenuItems, true);
             
            nav += "</nav>";
            
            return new StringBuilder(nav).ToString();
        }

        private string Print_UL(List<MenuItemDto> MenuItems, bool rootLevel = false)
        {
            string ul = $"<ul class=\"{((rootLevel) ? "nav sf-menu" : "")} \">";


            if (MenuItems?.Count > 0)
            {
                foreach (MenuItemDto Menu in MenuItems)
                {
                    if (Menu.ItemType == MenuItemTypeEnum.dropdown.ToString())
                    {
                        ul += print_dropdown(Menu);
                    }
                    else
                    {
                        ul +=  Print_Li(Menu);
                    }
                }
            }
             ul += "</ul>";
            return ul;
        }

        private string print_dropdown(MenuItemDto menu)
        {
            string  li = "<li>";
                    li += $"<a href=\"#\">{menu.Title}</a>";
                    li += Print_UL(menu.MenuItems, false);
                    li += "</li>";
            return li;
        }



        private string Print_Li(MenuItemDto Menu)
        {
            #region service
            if (Menu.ItemType.Equals(MenuItemTypeEnum.service.ToString(), StringComparison.OrdinalIgnoreCase))
            {
              return   GenerateLiItem(Menu, (string)paths[MenuItemTypeEnum.service.ToString()]);
            }
            #endregion

            #region static page
            if (Menu.ItemType.Equals(MenuItemTypeEnum.staticpage.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                return GenerateLiItem(Menu, (string)paths[MenuItemTypeEnum.staticpage.ToString()]);
            }
            #endregion

            #region page
            if (Menu.ItemType.Equals(MenuItemTypeEnum.page.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                return GenerateLiItem(Menu,  (string)paths[MenuItemTypeEnum.page.ToString()]);
            }
            #endregion

            #region product
            if (Menu.ItemType.Equals(MenuItemTypeEnum.product.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                return GenerateLiItem(Menu, (string)paths[MenuItemTypeEnum.product.ToString()]);
            }
            #endregion
             
            #region section
            if (Menu.ItemType.Equals(MenuItemTypeEnum.section.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                return GenerateLiItem(Menu, (string)paths[MenuItemTypeEnum.section.ToString()]);
            }
            #endregion
             
            #region gallery
            if (Menu.ItemType.Equals(MenuItemTypeEnum.gallery.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                return GenerateLiItem(Menu, (string)paths[MenuItemTypeEnum.gallery.ToString()]);
            }
            #endregion
             
            #region section_of_service
            if (Menu.ItemType.Equals(MenuItemTypeEnum.section_of_service.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                return GenerateLiItem(Menu, (string)paths[MenuItemTypeEnum.section_of_service.ToString()]);
            }
            #endregion
             
            #region Url
            if (Menu.ItemType.Equals(MenuItemTypeEnum.url.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                var target = (Menu.UrlTarget?.Length > 0) ? Menu.UrlTarget : "_blank";
                string li = "<li>";
                li += $"<a href=\"{Menu.Url}\" target=\"{target}\">{Menu.Title}</a>";
                li += "</li>";
                return li;

            }
            #endregion

            return "";
        }



        private string GenerateLiItem(MenuItemDto Menu,  string path = "")
        {
            string li = "<li>";
            if ("/".Equals(Menu.Url))
            {
                li += $"<a href=\"/{CultureInfo.CurrentCulture.Name}\">{Menu.Title}</a>";
            }
            else
            {
                li += $"<a href=\"{ path }/{ Menu.Url }\">{Menu.Title}</a>";
            }      
           li += "</li>";
            return li;
        }




        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = null;
            var menu = await _publicMenusService.GetNavbarMenuAsync();
            if (menu != null && menu.MenuItems != null)
            {
                output.Content.SetHtmlContent(PrintNav(menu.MenuItems));
            }
        }
    }
}


/*
 
									<ul class="nav sf-menu">


										<li class="active">
											<a href="index.html">Home</a>
											<ul>
												<li>
													
												</li>
												<li>
													<a href="index-2.html">Home 2</a>
												</li>
												<li>
													<a href="index_static.html">Static Intro</a>
												</li>
												<li>
													<a href="index_singlepage.html">Single Page</a>
												</li>
											</ul>
										</li>
										<li>
											<a href="about.html">About</a>
										</li>
     */

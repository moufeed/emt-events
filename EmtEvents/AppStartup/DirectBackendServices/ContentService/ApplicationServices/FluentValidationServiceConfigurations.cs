using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using TamTechBackendSDK.ContentService.Dtos.Product;
using TamTechBackendSDK.ContentService.Validators;
using TamTechBackendSDK.ContentService.Services.Menus.Dtos;
using TamTechBackendSDK.ContentService.Services.Dtos;
using TamTechBackendSDK.ContentService.Services.Galleries.Dtos;
using TamTechBackendSDK.ContentService.Services.Services.Validators;
using TamTechBackendSDK.ContentService.Services.Menus.Validators;
using TamTechBackendSDK.ContentService.Services.Galleries.Validators;

namespace EmtEvents.AppStartup.DirectBackendServices.ContentService.ApplicationServices
{
    public static class FluentValidationServiceConfigurations
    {
        public static void DirectBackendServices_ContentService_AddFluentValidationConfigurations(this IServiceCollection services)
        {

            #region Product Module

            services.AddTransient<IValidator<CreateProductDto>, CreateProductDtoValidator>();

            services.AddTransient<IValidator<UpdateProductDto>, UpdateProductDtoValidator>();

            services.AddTransient<IValidator<ProductDto>, ProductDtoValidator>();

            #endregion



            //#region Page Module

            //services.AddTransient<IValidator<CreateHtmlPageModel>, CreateHtmlPageModelValidator>();

            //services.AddTransient<IValidator<CreateSectionsPageModel>, CreateSectionsPageModelValidator>();

            //services.AddTransient<IValidator<UpdateHtmlPageModel>, UpdateHtmlPageModelValidator>();

            //services.AddTransient<IValidator<UpdateSectionsPageModel>, UpdateSectionsPageModelValidator>();

            //#endregion


            #region Menu Module

            services.AddTransient<IValidator<CreateMenuItemModel>, CreateMenuItemModelValidator>();

            services.AddTransient<IValidator<UpdateMenuItemModel>, UpdateMenuItemModelValidator>();

            services.AddTransient<IValidator<MenuItemKeysModel>, MenuItemKeysModelValidator>();

            services.AddTransient<IValidator<CreateMenuModel>, CreateMenuModelValidator>();

            #endregion


            #region Service Module

            services.AddTransient<IValidator<CreateServiceModel>, CreateServiceModelValidator>();

            services.AddTransient<IValidator<UpdateServiceModel>, UpdateServiceModelValidator>();

            #endregion


            #region Gallery Module

            services.AddTransient<IValidator<CreateGalleryModel>, CreateGalleryModelValidator>();

            services.AddTransient<IValidator<UpdateGalleryModel>, UpdateGalleryModelValidator>();

            #endregion



        }

    }
}

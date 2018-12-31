
using TamTechSDK.Common.Services.ContentService;
using TamTechSDK.Common.Services.ContentService.Brands;
using TamTechSDK.Common.Services.ContentService.Categories;
using TamTechSDK.Common.Services.ContentService.Products;
using TamTechSDK.Web.Services.Telemetry;
using TamTechSDK.Web.Controllers.Shop;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TamTechSDK.Web.Extensions.AutoMapper;
using TamTechSDK.Web.Models.Admin.Product;

namespace EmtEvents.Areas.Shop.Controllers
{


    public class ProductsController : ProductsBaseShopController
    {
        // private IProductsService _productsService;

        #region Ctors
        public ProductsController(
                                    ITelemetryClientService telemetryClientService,
                                    IProductsService productsService,
                                    IBrandsServices brandsService,
                                    ICategoriesServices categoriesService,
                                    IContentServices contentService
                                  )
            : base(telemetryClientService, productsService, brandsService,
                   categoriesService, contentService)
        {
            //this._productsService = productsService;
        }
        #endregion

        //public   IActionResult Index()
        //{
        //    return View();
        //}


        //public   IActionResult Compare()
        //{
        //    return View();
        //}


        //public IActionResult Details(int id)
        //{
        //    return View();
        //}



        //[HttpGet("{id}")]
        //public virtual async Task<ActionResult> GetByIdAsync(Guid id)
        //{
        //    try
        //    {
        //        var result = await _productsService.GetByIdAsync(id);
        //        if (result.Success)
        //        {
        //            var product = result.Data.MapFormToFormViewModel();
        //            if (product != null )
        //            {
        //                return View("Details", product);
        //            }
        //        }
        //        return View("Details", new ProductFormVM());

        //    }
        //    catch (Exception ex)
        //    {
        //        return View("Details", new ProductFormVM());

        //    }
        //}
    }
}
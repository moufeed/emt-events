using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TamTechSDK.Web.Controllers.Shop;
using TamTechSDK.Web.Services.Telemetry;

namespace EmtEvents.Areas.Shop.Controllers
{



    public class HomeController : HomeBaseShopController
    {
        #region Ctors

        #endregion
        public HomeController(ITelemetryClientService telemetryClientService)
        : base(telemetryClientService)
        {
        }

        //public async Task<IActionResult>  Index()
        //{
        //    return   View();
        //}
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TamTechSDK.Web.Models.Shared;

namespace EmtEvents.Areas.Portal.Controllers
{

    //  [Route("[Controller]/[Action]")]
    public class ErrorController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet("[Controller]/{statusCode}")]
        public IActionResult HandelError(string statusCode)
        {
            switch (statusCode)
            {
                case "404":
                    return View("Areas/Portal/Views/Error/NotFound.cshtml");
                case "500":
                    return View("Areas/Portal/Views/Error/Exception.cshtml");

                case "401":
                    JsonResult res = new JsonResult(new { });
                    res.StatusCode = 401;
                    return res;

            }
            return View("Areas/Portal/Views/Error/NotFound.cshtml");
        }



    }
}
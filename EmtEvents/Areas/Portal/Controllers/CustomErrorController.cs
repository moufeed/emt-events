using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EmtEvents.Areas.Portal.Controllers
{

    public class CustomErrorController : Controller
    {
        [HttpGet("[Controller]/{statusCode}")]
        public IActionResult Index(string statusCode)
        {

            switch (statusCode)
            {
                case "404":
                    return View("Areas/Portal/Views/Error/NotFound.cshtml");
                case "500":
                    return View();
            }
            return View();
        }
    }
}
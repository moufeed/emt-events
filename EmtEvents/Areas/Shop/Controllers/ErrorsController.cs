using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EmtEvents.Areas.Shop.Controllers
{
    [Area("Shop")]
    [Route("[Area]/[controller]")]
    public class ErrorsController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        [Route("{pName}")]
        public IActionResult NotFound(string pName)
        {
            return View();
        }

        [Route("[Controller]/{msg}")]
        public IActionResult Exception(string msg)
        {
            ViewBag.Message = msg;
            return View();
        }
    }
}
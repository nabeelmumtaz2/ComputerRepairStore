using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ComputerRepair.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(string step)
        {
            ViewBag.message = step;
            return View();
        }
    }
}
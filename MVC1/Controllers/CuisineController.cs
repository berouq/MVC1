using MVC1.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC1.Controllers
{
    [Log]
    public class CuisineController : Controller
    {
        // GET: Cuisine
        //[Authorize]
        public ActionResult Search(string name)
        {
            throw new Exception("something terrible");
            var message = Server.HtmlEncode(name);
            return Content("Cuisine name is" + message);
            //return RedirectToAction("index", "home", new { name = name });
            //return File(Server.MapPath("~/content/site.css"), "text/css");
            //return Json(new { Message = message, Name = "bg" }, JsonRequestBehavior.AllowGet);
        }


    }
}
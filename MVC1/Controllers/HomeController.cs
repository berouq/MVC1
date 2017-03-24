using MVC1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace MVC1.Controllers
{
    public class HomeController : Controller
    {
        OdeToFoodDBC _dbc = new OdeToFoodDBC();

        public ActionResult QuickSearch(string term)
        {

            var model =
                _dbc.Restaurants
                .OrderBy(r => r.Name)
                .Where(r => r.Name.StartsWith(term))
                .Take(50)
                .Select(r => new
                {
                    label = r.Name
                }
                );

            return Json(model, JsonRequestBehavior.AllowGet);
        }




        public ActionResult Index(string SearchTerm = null, int page = 1)
        {
            ViewBag.Title = "Home Page";
            
            var model =
                _dbc.Restaurants
                //.OrderByDescending(r => r.ReviewList.Average(review => review.Rating))
                .OrderBy(r => r.Id)
                .Where( r => SearchTerm == null || r.Name.StartsWith(SearchTerm))
                .Select(r => new RestaurantListViewModel
                    {
                        Id = r.Id,
                        Name = r.Name,
                        City = r.City,
                        Country = r.Country,
                        CountOfReviews = r.ReviewList.Count()
                    }
                ).ToPagedList(page, 10);

            if (Request.IsAjaxRequest())
            {
                return PartialView("_Restaurants", model);
            }
            else
            {
                return View(model);
            }
            
        }

        public ActionResult About()
        {
            //ViewBag.Message = "Your application description page.";
            //ViewBag.Location = "someplace";
            var localModel = new AboutModel();
            localModel.Name = "name from localmodel";
            localModel.Location = "someplace from localmodel";

            return View(localModel);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (_dbc != null)
            {
                _dbc.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
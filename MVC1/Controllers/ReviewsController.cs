using MVC1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC1.Controllers
{
    public class ReviewsController : Controller
    {

        OdeToFoodDBC _dbc = new OdeToFoodDBC();


        // GET: Reviews
        //public ActionResult Index([Bind(Prefix = "id")] int restaurantId)
        public ActionResult Index( int Id)
        {
            var restaurant = _dbc.Restaurants.Find(Id);
            if ( restaurant != null)
            {
                return View(restaurant);
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpGet]
        public ActionResult Create(int restaurantId)
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(ResaurantReview review)
        {
            if (ModelState.IsValid)
            {
                _dbc.Reviews.Add(review);
                _dbc.SaveChanges();
                return RedirectToAction("Index", new { id = review.RestaurantId });
            }
            else
            {
                return View(review);
            }
            
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = _dbc.Reviews.Find(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(ResaurantReview review)
        {
            if (ModelState.IsValid)
            {
                _dbc.Entry(review).State = EntityState.Modified;
                _dbc.SaveChanges();
                return RedirectToAction("Index", new { id = review.RestaurantId });
            }
            else
            {
                return View(review);
            }

        }



        protected override void Dispose(bool disposing)
        {
            _dbc.Dispose();
            base.Dispose(disposing);
        }


    }
}

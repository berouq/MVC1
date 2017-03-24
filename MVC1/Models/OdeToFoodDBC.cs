using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC1.Models
{
    public class OdeToFoodDBC : DbContext
    {
        public OdeToFoodDBC() : base("DefaultConnection") { }

        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<ResaurantReview> Reviews { get; set; }
    }
}
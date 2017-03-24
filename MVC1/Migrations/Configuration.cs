namespace MVC1.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using MVC1.Models;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<MVC1.Models.OdeToFoodDBC>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "MVC1.Models.OdeToFoodDBC";
        }

        protected override void Seed(OdeToFoodDBC context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Restaurants.AddOrUpdate(r => r.Name,
                        new Restaurant { Name = "seedr1", City = "c1", Country = "ctry1"},
                        new Restaurant { Name = "seedr2", City = "c2", Country = "ctry2" },
                        new Restaurant { Name = "seedr3", City = "c3", Country = "ctry3" },
                        new Restaurant
                        {
                            Name = "seedr4",
                            City = "c4",
                            Country = "ctry4",
                            ReviewList = new List<ResaurantReview>
                            {
                                new ResaurantReview {Rating = 9, Body = "icky" }
                            }
                        }

            );
            for (int i = 0;i<1000; i++)
            {
                context.Restaurants.AddOrUpdate(r => r.Name,
                                                new Restaurant
                                                {
                                                    Name = "seedloopr" + i.ToString().PadLeft(4, '0'),
                                                    City = "City",
                                                    Country = "Country"
                                                }
                );
            }
        }
    }
}

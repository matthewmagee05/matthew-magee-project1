using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RestaurantProjectMVC.Models
{
    public class RestaurantDbContext : DbContext
    {
        public RestaurantDbContext() : base("RestaurantDb") { }

        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Review> Resviews { get; set; }
    }
}
using System;
using System.Data.Entity;

namespace RestaurantProjectMVC.Models
{
    public class RestaurantDbContext : DbContext
    {
        public RestaurantDbContext() : base("RestaurantDb") { }

        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Review> Resviews { get; set; }
    }
}
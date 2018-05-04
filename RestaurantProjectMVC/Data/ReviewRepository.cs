using System;
using System.Collections.Generic;
using RestaurantProjectMVC.Models;
using System.Data.Entity;

namespace RestaurantProjectMVC.Data
{
    public class ReviewRepository : IRestaurantRepository<Review>

    {
        
        private RestaurantDbContext db = new RestaurantDbContext();
        private bool disposed = false;

        public ReviewRepository(RestaurantDbContext db)
        {
            this.db = db;
        }

        public void Delete(int id)
        {
            Review review = db.Resviews.Find(id);
            db.Resviews.Remove(review);
            db.SaveChanges();
        }

        public IEnumerable<Review> GetAll()
        {
            return db.Resviews.Include(r => r.Restaurant);
        }

        public IEnumerable<Restaurant> GetRestuarants()
        {
            return db.Restaurants;
        }

        public Review GetId(int id)
        {
            return db.Resviews.Find(id);
        }

        public void Insert(Review item)
        {
            db.Resviews.Add(item);
            db.SaveChanges();
        }

        
        public IEnumerable<Review> SearchAll(string a, string b)
        {
            throw new NotImplementedException();
        }

        public void Update(Review item)
        {
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
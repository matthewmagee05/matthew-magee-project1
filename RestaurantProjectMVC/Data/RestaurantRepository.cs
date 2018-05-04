using System;
using System.Collections.Generic;
using RestaurantProjectMVC.Models;
using System.Linq;
using System.Data.Entity;
using System.Web;

namespace RestaurantProjectMVC.Data
{
    public class RestaurantRepository : IRestaurantRepository<Restaurant>
    {
        private RestaurantDbContext db = new RestaurantDbContext();
        private bool disposed = false;

        public RestaurantRepository(RestaurantDbContext db)
        {
            this.db = db;
        }

        public void Delete(int id)
        {
            Restaurant restaurant = db.Restaurants.Find(id);
            db.Restaurants.Remove(restaurant);
            db.SaveChanges();
        }

        
        public IEnumerable<Restaurant> GetAll()
        {
            return db.Restaurants.ToList();
        }

        public Restaurant GetId(int id)
        {
            return db.Restaurants.Find(id);
            
        }

        public void Insert(Restaurant item)
        {
            db.Restaurants.Add(item);
            db.SaveChanges();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Restaurant> SearchAll(string a, string b)
        {
            if (!String.IsNullOrEmpty(a))
            {
                return db.Restaurants.Where(x => x.Name.ToLower().Contains(a.ToLower()));
            }

            if (!String.IsNullOrEmpty(b))
            {
                switch (b)
                {
                    case "three":
                        return db.Restaurants.ToList().OrderByDescending(x => x.averageRating()).Take(3);
                    case "name":
                        return db.Restaurants.OrderBy(x => x.Name);

                }
            }
            return db.Restaurants.ToList();
        }

        public void Update(Restaurant item)
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
using System;
using System.Collections.Generic;

namespace RestaurantProjectMVC.Data
{
   public interface IRestaurantRepository<T> : IDisposable
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> SearchAll(string a, string b);
        T GetId(int id);
        void Insert(T item);
        void Delete(int id);
        void Update(T item);
    }
}

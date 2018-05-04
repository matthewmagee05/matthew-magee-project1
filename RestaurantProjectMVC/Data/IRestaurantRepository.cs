using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantProjectMVC.Data
{
    interface IRestaurantRepository<T> : IDisposable
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> SearchAll(string a, string b);
        T GetId(int id);
        void Insert(T item);
        void Delete(int id);
        void Update(T item);
        void Save();
    }
}

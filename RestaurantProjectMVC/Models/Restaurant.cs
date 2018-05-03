using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantProjectMVC.Models
{
    public class Restaurant
    {
        public int RestaurantId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int ZipCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
        public string RestaruantImageURL { get; set; }


        public virtual ICollection<Review> Reviews { get; set; }

        public string averageRating()
        {
            var average = Reviews.Where(a => a.Rating != null)
                .Select(a => a.Rating)
                .DefaultIfEmpty(0)
                .Average();

            return Math.Round(average, 1).ToString();
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RestaurantProjectMVC.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string ReviewMessage { get; set; }
        public float Rating { get; set; }
        public string profileURL { get; set; }
        [ForeignKey("Restaurant")]
        public int RestarantId { get; set; }

        public virtual Restaurant Restaurant { get; set; }
    }
}
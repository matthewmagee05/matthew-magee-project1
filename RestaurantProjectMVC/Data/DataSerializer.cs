using System.Collections.Generic;
using RestaurantProjectMVC.Models;
using System.IO;
using Newtonsoft.Json;
using System.Configuration;

namespace RestaurantProjectMVC.Data
{
    class DataSerializer
    {

        public IList<Restaurant> myArray { get; set; }


        public IList<Restaurant> deserialize()
        {
            string filePath = ConfigurationManager.AppSettings["Path"];
            var jsonText = File.ReadAllText(filePath);
            myArray = JsonConvert.DeserializeObject<IList<Restaurant>>(jsonText);
            return myArray;
        }

        public string serialize()
        {
            var json = JsonConvert.SerializeObject(myArray);
            return json;
        }
    }
}
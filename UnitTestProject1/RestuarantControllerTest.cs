using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RestaurantProjectMVC.Models;
using RestaurantProjectMVC.Data;
using Shouldly;
using System.Collections.Generic;

namespace UnitTestProject1
{

    [TestClass]
    public class RestuarantControllerTest
    {
        private Restaurant restaurant = new Restaurant()
        {

            RestaurantId = 3,
            Name = "Wendys",
            Address = "453 Squire Drive",
            ZipCode = 99623,
            PhoneNumber = "907-342-8475",
            Description = "It's a good place to eat.",
            RestaruantImageURL = "/Content/img/rest3.jpg"
        };

        Mock<IRestaurantRepository<Restaurant>> mockRestaurantRepository = new Mock<IRestaurantRepository<Restaurant>>();

        [TestMethod]
        public void RestaurantRepositoryInsert()
        {
            mockRestaurantRepository.Setup(x => x.Insert(restaurant)); 
            mockRestaurantRepository.Object.Insert(restaurant);
            mockRestaurantRepository.Verify(x => x.Insert(restaurant), Times.Once()); 

        }

        [TestMethod]
        public void Get_Restaurant_By_Id()
        {
            mockRestaurantRepository.Setup(x => x.GetId(3))
            .Returns(restaurant);
            mockRestaurantRepository.Object.GetId(3).ShouldBe(restaurant); 
            mockRestaurantRepository.Verify(x => x.GetId(restaurant.RestaurantId), Times.Once()); 

        }

        [TestMethod]
        public void Delete_Restaurant_ById()
        {
            mockRestaurantRepository.Setup(x => x.Delete(restaurant.RestaurantId));
            mockRestaurantRepository.Object.Delete(restaurant.RestaurantId);

            mockRestaurantRepository.Setup(x => x.GetId(3));
            mockRestaurantRepository.Object.GetId(3).ShouldBe(null);

            mockRestaurantRepository.Verify(x => x.Delete(restaurant.RestaurantId), Times.Once); 

        }
        
        [TestMethod]
        public void getAllRestaurants()
        {
            IList<Restaurant> restaurant2 = new List<Restaurant>()
            {
                new Restaurant(){
                RestaurantId = 4,
                Name = "Wendys",
                Address = "453 Squire Drive",
                ZipCode = 99623,
                PhoneNumber = "907-342-8475",
                Description = "It's a good place to eat.",
                RestaruantImageURL = "/Content/img/rest3.jpg"
                }
            };
            mockRestaurantRepository.Setup(x => x.GetAll()).Returns(restaurant2);
            Assert.IsNotNull(mockRestaurantRepository.Object.GetAll());
        }

        [TestMethod]
        public void searchAllRestaurants()
        {
            IList<Restaurant> restaurant2 = new List<Restaurant>()
            {
                new Restaurant(){
                RestaurantId = 4,
                Name = "Wendys",
                Address = "453 Squire Drive",
                ZipCode = 99623,
                PhoneNumber = "907-342-8475",
                Description = "It's a good place to eat.",
                RestaruantImageURL = "/Content/img/rest3.jpg"
                }
            };
            mockRestaurantRepository.Setup(x => x.SearchAll(restaurant2[0].Name, restaurant2[0].RestaruantImageURL)).Returns(restaurant2);
            mockRestaurantRepository.Object.SearchAll(restaurant2[0].Name, restaurant2[0].RestaruantImageURL);
            Assert.AreEqual("Wendys", restaurant2[0].Name);
        }

    }
}

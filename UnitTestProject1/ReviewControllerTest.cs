using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RestaurantProjectMVC.Models;
using RestaurantProjectMVC.Data;
using Shouldly;
using System.Collections.Generic;

namespace UnitTestProject1
{
    class ReviewControllerTest
    {
        
        private Review review = new Review()
        {
            Id = 1,
            Username = "whateverDude",
            ReviewMessage = "whatever",
            Rating = 5.5f,
            profileURL = "fd/fsf/fs",
            RestarantId = 3
            
            
        };

        Mock<IRestaurantRepository<Review>> mockRestaurantRepository = new Mock<IRestaurantRepository<Review>>();

        [TestMethod]
        public void ReviewRepositoryInsert()
        {
            mockRestaurantRepository.Setup(x => x.Insert(review));
            mockRestaurantRepository.Object.Insert(review);
            mockRestaurantRepository.Verify(x => x.Insert(review), Times.Once());

        }

        [TestMethod]
        public void Get_Review_By_Id()
        {
            mockRestaurantRepository.Setup(x => x.GetId(1))
            .Returns(review);
            mockRestaurantRepository.Object.GetId(3).ShouldBe(review);
            mockRestaurantRepository.Verify(x => x.GetId(review.Id), Times.Once());

        }

        [TestMethod]
        public void Delete_Review_ById()
        {
            mockRestaurantRepository.Setup(x => x.Delete(review.Id));
            mockRestaurantRepository.Object.Delete(review.Id);

            mockRestaurantRepository.Setup(x => x.GetId(1));
            mockRestaurantRepository.Object.GetId(1).ShouldBe(null);

            mockRestaurantRepository.Verify(x => x.Delete(review.Id), Times.Once);

        }

        [TestMethod]
        public void getAllReviews()
        {
            IList<Review> review2 = new List<Review>()
            {
                 new Review(){
                    Id = 1,
                    Username = "whateverDude",
                    ReviewMessage = "whatever",
                    Rating = 5.5f,
                    profileURL = "fd/fsf/fs",
                    RestarantId = 3
                }
            };
            mockRestaurantRepository.Setup(x => x.GetAll()).Returns(review2);
            Assert.IsNotNull(mockRestaurantRepository.Object.GetAll());
        }

        [TestMethod]
        public void searchAllReviews()
        {
            IList<Review> review2 = new List<Review>()
            {
                new Review(){
                    Id = 1,
                    Username = "whateverDude",
                    ReviewMessage = "whatever",
                    Rating = 5.5f,
                    profileURL = "fd/fsf/fs",
                    RestarantId = 3
                }
            };
            mockRestaurantRepository.Setup(x => x.SearchAll(review2[0].Username, review2[0].profileURL)).Returns(review2);
            mockRestaurantRepository.Object.SearchAll(review2[0].Username, review2[0].profileURL);
            Assert.AreEqual("whateverDude", review2[0].Username);
        }
    }
}

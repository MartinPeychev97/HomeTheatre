using HomeTheatre.Data;
using HomeTheatre.Data.DbModels;
using HomeTheatre.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HomeTheatre.Test.ServicesTests.ReviewTests
{
    [TestClass]
    public class CreateReviewAsync_Should
    {
        [TestMethod]
        public async Task CreateValidReview()
        {
            //Arrange
            var options = Utilities.GetOptions(nameof(CreateValidReview));

            var idReview = Guid.NewGuid();
            var idTheatre = Guid.NewGuid();
            var createdOn = DateTime.UtcNow;

            var review = new Review()
            {
                Id = idReview,
                TheatreId = idTheatre,
                ReviewText = "TestReviewText",
                Rating = 2,
                Author = "testAuthor",
                CreatedOn = createdOn
            };
            //Assert
            using (var assertContext = new TheatreContext(options))
            {
                var sut = new ReviewServices(assertContext);
                var result = await sut.CreateReviewAsync(review);

                Assert.IsInstanceOfType(result, typeof(Review));
                Assert.AreEqual(idReview, result.Id);
                Assert.AreEqual(idTheatre, result.TheatreId);
                Assert.AreEqual(createdOn, result.CreatedOn);
                Assert.AreEqual("TestReviewText", result.ReviewText);
                Assert.AreEqual("testAuthor", result.Author);

            }
        }

        [TestMethod]
        public async Task ThrowWhen_ModelPassedIsNull()
        {

            //Arrange
            var options = Utilities.GetOptions(nameof(CreateValidReview));


            using (var assertContext = new TheatreContext(options))
            {
                //Act & Assert
                var sut = new ReviewServices(assertContext);
                await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => sut.CreateReviewAsync(null));
            }
        }
    }
}


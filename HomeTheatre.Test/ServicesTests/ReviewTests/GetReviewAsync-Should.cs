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
    public class GetReviewAsync_Should
    {
        [TestMethod]
        public async Task ReturnCorrectReviews()
        {
            var options = Utilities.GetOptions(nameof(ReturnCorrectReviews));


            var id = Guid.NewGuid();
            var theatreId = Guid.NewGuid();
            var createdOn = DateTime.UtcNow;

            var review = new Review
            {
                Id = id,
                TheatreId = theatreId,
                ReviewText = "TestReviewText",
                Rating = 2,
                Author = "testAuthor",
                CreatedOn = createdOn
            };


            using (var arrangeContext = new TheatreContext(options))
            {
                await arrangeContext.Reviews.AddAsync(review);
                await arrangeContext.SaveChangesAsync();
            }

            using (var assertContext = new TheatreContext(options))
            {
                var sut = new ReviewServices(assertContext);
                var result = await sut.GetReviewAsync(theatreId);

                
                Assert.IsInstanceOfType(result, typeof(Review));
                Assert.AreEqual(id, result.Id);
                Assert.AreEqual(review.Rating, result.Rating);
                Assert.AreEqual(theatreId, result.TheatreId);
                Assert.AreEqual(createdOn, result.CreatedOn);
                Assert.AreEqual("TestReviewText", result.ReviewText);
                Assert.AreEqual("testAuthor", result.Author);
            }
        }
    }
}

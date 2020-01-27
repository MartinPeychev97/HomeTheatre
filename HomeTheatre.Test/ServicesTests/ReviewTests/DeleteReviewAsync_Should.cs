using HomeTheatre.Data;
using HomeTheatre.Data.DbModels;
using HomeTheatre.Services.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HomeTheatre.Test.ServicesTests.ReviewTests
{
    [TestClass]
    public class DeleteReviewAsync_Should
    {
        public async Task CorrectlyDeletedReview()
        {
            var options = Utilities.GetOptions(nameof(CorrectlyDeletedReview));


            var id = Guid.NewGuid();
            var theatreId = Guid.NewGuid();
            var userId = Guid.NewGuid();
            var createdOn = DateTime.UtcNow;

            var user = new User
            {
                Id = userId,
                UserName = "testUser",
            };
            var theatre = new Theatre
            {
                Id = theatreId,
            };
            var review = new Review
            {
                Id = id,
                TheatreId = theatreId,
                ReviewText = "TestReviewText",
                Rating = 2,
                Author = "testAuthor",
                CreatedOn = createdOn
            };
            theatre.Reviews.Add(review);
            user.Reviews.Add(review);

            using (var assertContext = new TheatreContext(options))
            {
                await assertContext.Users.AddAsync(user);
                await assertContext.Reviews.AddAsync(review);
                await assertContext.Theatres.AddAsync(theatre);
                await assertContext.SaveChangesAsync();
                var commentServices = new ReviewServices(assertContext);
                var result = await commentServices.DeleteReviewAsync(review.Id);
            }
            using (var assertContext = new TheatreContext(options))
            {
                var result = await assertContext.Comments.FirstAsync();
                Assert.AreEqual(true, result.IsDeleted);
            }

        }

        [TestMethod]
        public async Task ThrowWhen_NoReviewFound()
        {
            // Arrange
            var options = Utilities.GetOptions(nameof(ThrowWhen_NoReviewFound));

            var reviewId = Guid.NewGuid();

            using (var assertContext = new TheatreContext(options))
            {
                //Act & Assert
                var sut = new ReviewServices(assertContext);
                await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => sut.DeleteReviewAsync(reviewId));
            }
        }

    }
}

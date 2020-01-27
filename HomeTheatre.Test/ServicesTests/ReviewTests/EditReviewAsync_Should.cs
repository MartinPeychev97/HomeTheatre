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
    class EditReviewAsync_Should
    {
        [TestMethod]
        public async Task CorrectlyEditedReview()
        {
            //Arrange
            var options = Utilities.GetOptions(nameof(CorrectlyEditedReview));


            var id = Guid.NewGuid();
            var theatreId = Guid.NewGuid();
            var userId = Guid.NewGuid();

            var createdOn = DateTime.UtcNow;

            var entity = new Review
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
                await arrangeContext.Reviews.AddAsync(entity);
                await arrangeContext.SaveChangesAsync();
            }


            using (var assertContext = new TheatreContext(options))
            {
                var sut = new ReviewServices(assertContext);

                var result = await sut.EditReviewAsync(id, "newbody");

                var modifiedComment = await assertContext.Comments.FirstAsync();

                Assert.AreEqual("newText", modifiedComment.CommentText);

            }
        }

        [TestMethod]
        public async Task ReturnCorrectType()
        {
            //Arrange
            var options = Utilities.GetOptions(nameof(ReturnCorrectType));


            var id = Guid.NewGuid();
            var theatreId = Guid.NewGuid();
            var userId = Guid.NewGuid();

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
                //Act & Assert
                var sut = new CommentServices(assertContext);

                var result = await sut.EditCommentAsync(id, "newText");
                Assert.IsInstanceOfType(result, typeof(Comment));
            }
        }

    }
}

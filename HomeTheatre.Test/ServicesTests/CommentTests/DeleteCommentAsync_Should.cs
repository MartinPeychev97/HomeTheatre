using HomeTheatre.Data;
using HomeTheatre.Data.DbModels;
using HomeTheatre.Services.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

using System.Threading.Tasks;

namespace HomeTheatre.Test.ServicesTests.CommentTests
{
    [TestClass]
    public class DeleteCommentAsync_Should
    {
        public async Task CorrectlyDeletedComment()
        {
            var options = Utilities.GetOptions(nameof(CorrectlyDeletedComment));


            var id = Guid.NewGuid();
            var reviewId = Guid.NewGuid();
            var userId = Guid.NewGuid();
            var createdOn = DateTime.UtcNow;

            var user = new User
            {
                Id = userId,
                UserName = "testUser",
            };
            var review = new Review
            {
                Id=reviewId,
                Author=user.UserName
            };
            var comment = new Comment 
            {
                Id=id,
                Review=review,
                ReviewId=reviewId,
                User=user,
                UserId=user.Id,
                CreatedOn=createdOn
            };
            review.Comments.Add(comment);
            user.Comments.Add(comment);

            using (var assertContext=new TheatreContext(options))
            {
                await assertContext.Users.AddAsync(user);
                await assertContext.Reviews.AddAsync(review);
                await assertContext.Comments.AddAsync(comment);
                await assertContext.SaveChangesAsync();
                var commentServices = new CommentServices(assertContext);
                var result = await commentServices.DeleteCommentAsync(id,reviewId);
            }
            using (var assertContext = new TheatreContext(options))
            {
                var result = await assertContext.Comments.FirstAsync();
                Assert.AreEqual(true, result.IsDeleted);
            }

        }

        [TestMethod]
        public async Task ThrowWhen_NoCommentFound()
        {
            // Arrange
            var options = Utilities.GetOptions(nameof(ThrowWhen_NoCommentFound));


            var id = Guid.NewGuid();
            var reviewId = Guid.NewGuid();

            using (var assertContext = new TheatreContext(options))
            {
                //Act & Assert
                var sut = new CommentServices(assertContext);
                await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => sut.DeleteCommentAsync(id, reviewId));
            }
        }

    }
}

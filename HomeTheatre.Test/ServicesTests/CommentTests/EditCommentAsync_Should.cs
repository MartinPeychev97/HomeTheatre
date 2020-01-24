using HomeTheatre.Data;
using HomeTheatre.Data.DbModels;
using HomeTheatre.Services.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HomeTheatre.Test.ServicesTests.CommentTests
{
    [TestClass]
    public class EditCommentAsync_Should
    {
        [TestMethod]
        public async Task CorrectlyEditedComment()
        {
            //Arrange
            var options = Utilities.GetOptions(nameof(CorrectlyEditedComment));


            var id = Guid.NewGuid();
            var reviewId = Guid.NewGuid();
            var userId = Guid.NewGuid();

            var createdOn = DateTime.UtcNow;

            var entity = new Comment
            {

                Id = id,
                ReviewId = reviewId,
                UserId = userId,
                CommentText = "testCommentText",
                CreatedOn = createdOn
            };

            using (var arrangeContext = new TheatreContext(options))
            {
                await arrangeContext.Comments.AddAsync(entity);
                await arrangeContext.SaveChangesAsync();
            }


            using (var assertContext = new TheatreContext(options))
            {
                var sut = new CommentServices(assertContext);

                var result = await sut.EditCommentAsync(id, "newbody");

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
            var reviewId = Guid.NewGuid();
            var userId = Guid.NewGuid();

            var createdOn = DateTime.UtcNow;

            var comment = new Comment
            {
                Id = id,
                ReviewId = reviewId,
                UserId = userId,
                Author = "testPoster",
                CommentText = "testbody",
                CreatedOn = createdOn
            };

            using (var arrangeContext = new TheatreContext(options))
            {
                await arrangeContext.Comments.AddAsync(comment);
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

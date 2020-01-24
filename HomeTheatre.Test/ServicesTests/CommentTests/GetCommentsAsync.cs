using HomeTheatre.Data;
using HomeTheatre.Data.DbModels;
using HomeTheatre.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTheatre.Test.ServicesTests.CommentTests
{
    [TestClass]
    public class GetCommentsAsync
    {
        [TestMethod]
        public async Task ReturnCorrectComments()
        {
            var options = Utilities.GetOptions(nameof(ReturnCorrectComments));


            var id = Guid.NewGuid();
            var id02 = Guid.NewGuid();
            var reviewId = Guid.NewGuid();
            var createdOn = DateTime.UtcNow;

            var comment = new Comment
            {
                Id = id,
                ReviewId = reviewId,
                UserId = Guid.NewGuid(),
                CommentText = "testCommentText",
                CreatedOn = createdOn
            };

             var comment02 = new Comment
             {
                 Id = id02,
                 ReviewId = reviewId,
                 UserId = Guid.NewGuid(),
                 CommentText = "testCommentText",
                 CreatedOn = createdOn
             };


            using (var arrangeContext = new TheatreContext(options))
            {
                await arrangeContext.Comments.AddAsync(comment);
                await arrangeContext.Comments.AddAsync(comment02);
                await arrangeContext.SaveChangesAsync();
            }

            using (var assertContext = new TheatreContext(options))
            {
                var sut = new CommentServices(assertContext);
                var result = await sut.GetCommentsAsync(reviewId);

                Assert.IsInstanceOfType(result, typeof(Comment));
                Assert.AreEqual("testbody", result.Count());
                Assert.AreEqual(2, result.Count());
                Assert.AreEqual(comment.CommentText, result.First().CommentText);
                Assert.AreEqual(comment.Id, result.First().Id);
                Assert.AreEqual(comment02.CommentText, result.Last().CommentText);
                Assert.AreEqual(comment02.Id, result.Last().Id);
            }
        }
    }
}

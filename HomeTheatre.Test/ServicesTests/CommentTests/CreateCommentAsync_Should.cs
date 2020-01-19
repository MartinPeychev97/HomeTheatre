using HomeTheatre.Data;
using HomeTheatre.Data.DbModels;
using HomeTheatre.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HomeTheatre.Test.ServicesTests.CommentTests
{
    [TestClass]
    public class CreateCommentAsync_Should
    {
        [TestMethod]
        public async Task CreateValidComment()
        {
            //Arrange
            var options = Utilities.GetOptions(nameof(CreateValidComment));

            var idComment = Guid.NewGuid();
            var idUser = Guid.NewGuid();
            var createdOn = DateTime.UtcNow;

            var comment = new Comment()
            {
                Id = idComment,
                UserId = idUser,
                CommentText = "TestCommentText",
                Author = "testAuthor",
                CreatedOn = createdOn
            };
            //Assert
            using (var assertContext = new TheatreContext(options))
            {
                var sut = new CommentServices(assertContext);
                var result = await sut.CreateCommentAsync(comment);

                Assert.IsInstanceOfType(result, typeof(Comment));
                Assert.AreEqual(idComment, result.Id);
                Assert.AreEqual(idUser, result.UserId);
                Assert.AreEqual(createdOn, result.CreatedOn);
                Assert.AreEqual("TestCommentText", result.CommentText);
                Assert.AreEqual("testAuthor", result.Author);

            }
        }
    }
}

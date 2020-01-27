using HomeTheatre.Data.DbModels;
using HomeTheatre.Mappers;
using HomeTheatre.Models.Comment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeTheatre.Test.MapperTests
{
    [TestClass]
    public class CommentViewModelMapper_Should
    {
        [TestMethod]
        public void ReturnValidInstanceOfClass()
        {
            //Arrange
            var sut = new CommentViewModelMapper();

            var comment = new Comment
            {

                Id = Guid.NewGuid(),
                ReviewId = Guid.NewGuid(),
                UserId = Guid.NewGuid(),
                Author = "testAuthor",
                CommentText = "TestText",
                CreatedOn = DateTime.MinValue,
            };

            //Act
            var result = sut.MapFrom(comment);

            //Assert
            Assert.IsInstanceOfType(result, typeof(CommentViewModel));
        }

        [TestMethod]
        public void EnsureMapperMapsCorrectly()
        {
            //Arrange
            var sut = new CommentViewModelMapper();

            var comment = new Comment
            {
                Id = Guid.NewGuid(),
                ReviewId = Guid.NewGuid(),
                UserId = Guid.NewGuid(),
                Author = "testAuthor",
                CommentText = "TestText",
                CreatedOn = DateTime.MinValue,
            };

            //Act
            var result = sut.MapFrom(comment);

            //Assert
            Assert.AreEqual(result.Id, comment.Id);
            Assert.AreEqual(result.ReviewId, comment.ReviewId);
            Assert.AreEqual(result.UserId, comment.UserId);
            Assert.AreEqual(result.Author, comment.Author);
            Assert.AreEqual(result.CommentText, comment.CommentText);
            Assert.AreEqual(result.CreatedOn, comment.CreatedOn);
        }


        [TestMethod]
        public void MapFrom_Should_ReturnCorrectInstanceOfCommentCollection()
        {
            //Arrange
            var sut = new CommentViewModelMapper();

            var comment = new List<Comment>
            {
                new Comment
                {
                Id = Guid.NewGuid(),
                ReviewId = Guid.NewGuid(),
                UserId = Guid.NewGuid(),
                Author = "testAuthor",
                CommentText = "TestText",
                CreatedOn = DateTime.MinValue,
                },
                new Comment
                {
                Id = Guid.NewGuid(),
                ReviewId = Guid.NewGuid(),
                UserId = Guid.NewGuid(),
                Author = "testAuthor02",
                CommentText = "TestText02",
                CreatedOn = DateTime.MinValue,
                },
            };

            //Act
            var result = sut.MapFrom(comment);

            //Assert
            Assert.IsInstanceOfType(result, typeof(List<CommentViewModel>));
        }

        [TestMethod]
        public void MapFrom_ShouldReturnCorrectNumberOfComments()
        {
            //Arrange
            var sut = new CommentViewModelMapper();

            var comment = new List<Comment>
            {
                new Comment
                {
                Id = Guid.NewGuid(),
                ReviewId = Guid.NewGuid(),
                UserId = Guid.NewGuid(),
                Author = "testAuthor",
                CommentText = "TestText",
                CreatedOn = DateTime.MinValue,
                },
                new Comment
                {
                Id = Guid.NewGuid(),
                ReviewId = Guid.NewGuid(),
                UserId = Guid.NewGuid(),
                Author = "testAuthor02",
                CommentText = "TestText02",
                CreatedOn = DateTime.MinValue,
                },
            };

            //Act
            var result = sut.MapFrom(comment);

            //Assert
            Assert.AreEqual(2, result.Count());
        }
    }
}

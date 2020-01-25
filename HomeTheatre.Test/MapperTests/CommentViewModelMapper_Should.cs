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
            Assert.IsInstanceOfType(result, typeof(CommentViewModelMapper));
        }

        [TestMethod]
        public void EnsureMapperMapsCorrectly()
        {
            //Arrange
            var sut = new CommentViewModelMapper();

            var barComment = new Comment
            {
                Id = Guid.NewGuid(),
                ReviewId = Guid.NewGuid(),
                UserId = Guid.NewGuid(),
                Author = "testAuthor",
                CommentText = "TestText",
                CreatedOn = DateTime.MinValue,
            };

            //Act
            var result = sut.MapFrom(barComment);

            //Assert
            Assert.AreEqual(result.Id, barComment.Id);
            Assert.AreEqual(result.ReviewId, barComment.ReviewId);
            Assert.AreEqual(result.UserId, barComment.UserId);
            Assert.AreEqual(result.Author, barComment.Author);
            Assert.AreEqual(result.CommentText, barComment.CommentText);
            Assert.AreEqual(result.CreatedOn, barComment.CreatedOn);
        }


        [TestMethod]
        public void MapFrom_Should_ReturnCorrectInstanceOfCommentCollection()
        {
            //Arrange
            var sut = new CommentViewModelMapper();

            var barComment = new List<Comment>
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
            var result = sut.MapFrom(barComment);

            //Assert
            Assert.IsInstanceOfType(result, typeof(List<CommentViewModel>));
        }

        [TestMethod]
        public void MapFrom_ShouldReturnCorrectNumberOfComments()
        {
            //Arrange
            var sut = new CommentViewModelMapper();

            var barComment = new List<Comment>
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
            var result = sut.MapFrom(barComment);

            //Assert
            Assert.AreEqual(2, result.Count());
        }
    }
}

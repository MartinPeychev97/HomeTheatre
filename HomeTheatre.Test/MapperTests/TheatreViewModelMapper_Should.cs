using HomeTheatre.Data.DbModels;
using HomeTheatre.Mappers;
using HomeTheatre.Models.Theatre;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeTheatre.Test.MapperTests
{
    [TestClass]
   public class TheatreViewModelMapper_Should
    {
        [TestMethod]
        public void ReturnCorrectInstanceOf_TheatreViewModel()
        {
            //Arrange
            var sut = new TheatreViewModelMapper();

            var bar = new Theatre
            {
                Id = Guid.NewGuid(),
                Name = "testName",
                AboutInfo = "testAboutInfo",
                ImagePath = "testPath",
                Location = "testLocation",
                Phone = "3456787678",
                AverageRating =4,
                NumberOfReviews=2
            };

            //Act
            var result = sut.MapFrom(bar);

            //Assert
            Assert.IsInstanceOfType(result, typeof(TheatreViewModel));
        }

        [TestMethod]
        public void MapCorrectlyFromTheatreToViewModel()
        {
            //Arrange
            var sut = new TheatreViewModelMapper();

            var theatre = new Theatre
            {

                Id = Guid.NewGuid(),
                Name = "testName",
                AboutInfo = "testAboutInfo",
                ImagePath = "testPath",
                Location = "testLocation",
                Phone = "3456787678",
                AverageRating = 4,
                NumberOfReviews = 2
            };

            //Act
            var result = sut.MapFrom(theatre);

            //Assert
            Assert.AreEqual(result.Id, theatre.Id);
            Assert.AreEqual(result.Name, theatre.Name);
            Assert.AreEqual(result.AboutInfo, theatre.AboutInfo);
            Assert.AreEqual(result.ImagePath, theatre.ImagePath);
            Assert.AreEqual(result.Location, theatre.Location);
            Assert.AreEqual(result.Phone, theatre.Phone);
            Assert.AreEqual(result.AverageRating, theatre.AverageRating);
            Assert.AreEqual(result.NumberOfReviews, theatre.NumberOfReviews);
        }

        [TestMethod]
        public void ShouldReturnCorrectInstanceOfTheatreCollection()
        {
            //Arrange
            var sut = new TheatreViewModelMapper();

            var theatres = new List<Theatre>()
            {
                new Theatre
                {
                Id = Guid.NewGuid(),
                Name = "testName",
                AboutInfo = "testAboutInfo",
                ImagePath = "testPath",
                Location = "testLocation",
                Phone = "3456787678",
                AverageRating = 4,
                NumberOfReviews = 2
                },
                new Theatre
                {
                Id = Guid.NewGuid(),
                Name = "testName01",
                AboutInfo = "testAboutInfo01",
                ImagePath = "testPath01",
                Location = "testLocation",
                Phone = "3456787678",
                AverageRating = 4,
                NumberOfReviews = 2
                }
            };

            //Act
            var result = sut.MapFrom(theatres);

            //Assert
            Assert.IsInstanceOfType(result, typeof(List<TheatreViewModel>));
        }
        [TestMethod]
        public void ShouldReturnCorrectNumberOfBars()
        {
            //Arrange
            var sut = new TheatreViewModelMapper();

            var theatres = new List<Theatre>()
            {
                new Theatre
                {
                  Id = Guid.NewGuid(),
                Name = "testName",
                AboutInfo = "testAboutInfo",
                ImagePath = "testPath",
                Location = "testLocation",
                Phone = "3456787678",
                AverageRating = 4,
                NumberOfReviews = 2
                },
                new Theatre
                {
                   Id = Guid.NewGuid(),
                Name = "testName01",
                AboutInfo = "testAboutInfo01",
                ImagePath = "testPath01",
                Location = "testLocation",
                Phone = "3456787678",
                AverageRating = 4,
                NumberOfReviews = 2
                }
            };

            //Act
            var result = sut.MapFrom(theatres);

            //Assert
            Assert.AreEqual(2, result.Count());
        }
    }
}

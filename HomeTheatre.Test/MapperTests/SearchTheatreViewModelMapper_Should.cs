using HomeTheatre.Mappers;
using HomeTheatre.Models.Theatre;
using HomeTheatre.Services.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeTheatre.Test.MapperTests
{
    [TestClass]
    public class SearchTheatreViewModelMapper_Should
    {
        [TestMethod]
        public void MapFrom_Should_ReturnCorrectInstanceOf_TheatreViewModel()
        {
            //Arrange
            var sut = new SearchTheatreViewModelMapper();

            var theatre = new SearchTheatre
            {
                Id = Guid.NewGuid(),
                Name = "testName",
                Location = "testLocation",
                AverageRating = 5,
            };

            //Act
            var result = sut.MapFrom(theatre);

            //Assert
            Assert.IsInstanceOfType(result, typeof(TheatreViewModel));
        }

        [TestMethod]
        public void MapFrom_Should_Return_CorrectInstanceOf_TheatreViewModel()
        {
            //Arrange
            var sut = new SearchTheatreViewModelMapper();

            var theatre = new SearchTheatre
            {
                Id = Guid.NewGuid(),
                Name = "testName",
                Location = "testLocation",
                AverageRating = 5,
            };

            //Act
            var result = sut.MapFrom(theatre);

            //Assert
            Assert.AreEqual(result.Id, theatre.Id);
            Assert.AreEqual(result.Name, theatre.Name);
            Assert.AreEqual(result.Location, theatre.Location);
            Assert.AreEqual(result.AverageRating, theatre.AverageRating);
        }

        [TestMethod]
        public void MapFrom_Should_ReturnCorrectInstanceOfCollectionOfTheatreViewModel()
        {
            //Arrange
            var sut = new SearchTheatreViewModelMapper();

            var theatres = new List<SearchTheatre>()
            {
                new SearchTheatre
                {
                    Id = Guid.NewGuid(),
                    Name = "testName",
                    Location = "testLocation",
                    Phone="testPhone"

                },
                new SearchTheatre
                {
                    Id = Guid.NewGuid(),
                    Name = "testName2",
                    Location = "testLocation",
                    Phone="testPhone"

                }
            };

            //Act
            var result = sut.MapFrom(theatres);

            //Assert
            Assert.IsInstanceOfType(result, typeof(List<TheatreViewModel>));
        }

        [TestMethod]
        public void MapFromCollection_Should_ReturnCorrectNumberOfTheatres()
        {
            //Arrange
            var sut = new SearchTheatreViewModelMapper();

            var theatres = new List<SearchTheatre>()
            {
                new SearchTheatre
                {
                    Id = Guid.NewGuid(),
                    Name = "testName",
                    Location = "testLocation",
                    Phone="testPhone",
                },
                new SearchTheatre
                {
                    Id = Guid.NewGuid(),
                    Name = "testName2",
                    Location = "testLocation",
                    Phone="testPhone"
                }
            };

            //Act
            var result = sut.MapFrom(theatres);

            //Assert
            Assert.AreEqual(2, result.Count());
        }
    }
}


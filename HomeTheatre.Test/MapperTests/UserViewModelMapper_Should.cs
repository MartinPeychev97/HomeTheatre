using HomeTheatre.Data.DbModels;
using HomeTheatre.Mappers;
using HomeTheatre.Models.User;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeTheatre.Test.MapperTests
{
    [TestClass]
    public class UserViewModelMapper_Should
    {
        [TestMethod]
        public void MapFrom_Should_ReturnCorrectInstanceOf_UserViewModel()
        {
            //Arrange
            var sut = new UserViewModelMapper();

            var user = new User
            {
                Id = Guid.NewGuid(),
                UserName = "testName",
                Email = "testEmail@test.test",
                CreatedOn = DateTime.Now,
                IsBanned = false,
            };

            //Act
            var result = sut.MapFrom(user);

            //Assert
            Assert.IsInstanceOfType(result, typeof(UserViewModel));
        }

        [TestMethod]
        public void MapFrom_Should_CorrectlyMapFrom_User_To_UserViewModel()
        {
            //Arrange
            var sut = new UserViewModelMapper();

            var user = new User
            {
                Id = Guid.NewGuid(),
                UserName = "testName",
                Email = "testEmail@test.test",
                CreatedOn = DateTime.Now,
                IsBanned = false,
            };

            //Act
            var result = sut.MapFrom(user);

            //Assert
            Assert.AreEqual(result.Id, user.Id);
            Assert.AreEqual(result.Name, user.Name);
            Assert.AreEqual(result.Email, user.Email);
            Assert.AreEqual(result.CreatedOn, user.CreatedOn);
            Assert.AreEqual(result.IsBanned, user.IsBanned);
        }

        [TestMethod]
        public void MapFrom_Should_ReturnCorrectInstanceOfCollection_UserViewModel()
        {
            //Arrange
            var sut = new UserViewModelMapper();

            var users = new List<User>()
            {
                new User
                {
                    Id = Guid.NewGuid(),
                    UserName = "testName",
                    Email = "testEmail@gmail.com",
                    CreatedOn = DateTime.Now,
                    IsBanned = false,
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    UserName = "testName2",
                    Email = "testEmail2@gmail.com",
                    CreatedOn = DateTime.Now,
                    IsBanned = false,
                }
            };

            //Act
            var result = sut.MapFrom(users);

            //Assert
            Assert.IsInstanceOfType(result, typeof(List<UserViewModel>));
        }

        [TestMethod]
        public void MapFromCollection_Should_ReturnCorrectUserCount()
        {
            //Arrange
            var sut = new UserViewModelMapper();

            var users = new List<User>()
            {
                new User
                {
                    Id = Guid.NewGuid(),
                    UserName = "testName",
                    Email = "testEmail@test.test",
                    CreatedOn = DateTime.Now,
                    IsBanned = false,
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    UserName = "testName2",
                    Email = "testEmail2@test.test",
                    CreatedOn = DateTime.Now,
                    IsBanned = false,
                }
            };

            //Act
            var result = sut.MapFrom(users);

            //Assert
            Assert.AreEqual(2, result.Count());
        }
    }
}


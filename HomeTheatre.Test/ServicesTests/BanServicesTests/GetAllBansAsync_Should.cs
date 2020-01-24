using HomeTheatre.Data;
using HomeTheatre.Data.DbModels;
using HomeTheatre.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTheatre.Test.ServicesTests.BanServicesTests
{
    [TestClass]
    public class GetAllBansAsync_Should
    {
        [TestMethod]
        public async Task ReturnCorrectTypeActiveUsers()
        {
            var options = Utilities.GetOptions(nameof(ReturnCorrectTypeActiveUsers));
            var testGuid = Guid.NewGuid();
            var testGuid2 = Guid.NewGuid();

            var users = new List<User>
            {
                new User { Id = testGuid, UserName = "Martin", IsBanned = false },
                new User { Id = testGuid2, UserName = "Nelly", IsBanned = false },
            };

            using (var actContext = new TheatreContext(options))
            {
                var sut = new BanServices(actContext);
                await actContext.Users.AddAsync(users[0]);
                await actContext.Users.AddAsync(users[1]);
                await actContext.SaveChangesAsync();

                var result = await sut.GetAllBannedUsersAsync("active");
                Assert.IsInstanceOfType(result, typeof(ICollection<User>));
            }
        }

        [TestMethod]
        public async Task ReturnCorrectObjects_ActiveUsers()
        {
            //Arrange
            var options = Utilities.GetOptions(nameof(ReturnCorrectObjects_ActiveUsers));
            var testGuid = Guid.NewGuid();
            var testGuid02 = Guid.NewGuid();

            var users = new List<User>
            {
                new User { Id = testGuid, UserName = "Martin", IsBanned = false },
                new User { Id = testGuid02, UserName = "Nelly", IsBanned = false },
            };


            using (var actContext = new TheatreContext(options))
            {
                //Act & Assert
                var sut = new BanServices(actContext);
                await actContext.Users.AddAsync(users[0]);
                await actContext.Users.AddAsync(users[1]);
                await actContext.SaveChangesAsync();

                var result = await sut.GetAllBannedUsersAsync("active");
                Assert.AreEqual(users[0].UserName, result.AsQueryable().First().UserName);
                Assert.AreEqual(users[0].Id, result.AsQueryable().First().Id);
                Assert.AreEqual(users[0].IsBanned, result.AsQueryable().First().IsBanned);
                Assert.AreEqual(users[1].UserName, result.AsQueryable().Last().UserName);
                Assert.AreEqual(users[1].Id, result.AsQueryable().Last().Id);
                Assert.AreEqual(users[1].IsBanned, result.AsQueryable().Last().IsBanned);
            }
        }
        [TestMethod]
        public async Task ReturnCorrectType_BannedUsers()
        {
            //Arrange
            var options = Utilities.GetOptions(nameof(ReturnCorrectType_BannedUsers));
            var testGuid = Guid.NewGuid();
            var testGuid2 = Guid.NewGuid();

            var users = new List<User>
            {
                new User { Id = testGuid, UserName = "Martin", IsBanned = true },
                new User { Id = testGuid2, UserName = "Nelly", IsBanned = true },
            };

            using (var actContext = new TheatreContext(options))
            {
                //Act & Assert
                var sut = new BanServices(actContext);
                await actContext.Users.AddAsync(users[0]);
                await actContext.Users.AddAsync(users[1]);
                await actContext.SaveChangesAsync();

                var result = await sut.GetAllBannedUsersAsync("banned");
                Assert.IsInstanceOfType(result, typeof(ICollection<User>));
            }
        }

        [TestMethod]
        public async Task ReturnCorrectObjects_BannedUsers()
        {
            //Arrange
            var options = Utilities.GetOptions(nameof(ReturnCorrectObjects_BannedUsers));
            var testGuid = Guid.NewGuid();
            var testGuid2 = Guid.NewGuid();

            var users = new List<User>
            {
                new User { Id = testGuid, UserName = "Martin", IsBanned = true },
                new User { Id = testGuid2, UserName = "Nelly", IsBanned = true },
            };

            using (var actContext = new TheatreContext(options))
            {
                //Act & Assert
                var sut = new BanServices(actContext);
                await actContext.Users.AddAsync(users[0]);
                await actContext.Users.AddAsync(users[1]);
                await actContext.SaveChangesAsync();

                var result = await sut.GetAllBannedUsersAsync("banned");
                Assert.AreEqual(users[0].UserName, result.AsQueryable().First().UserName);
                Assert.AreEqual(users[0].Id, result.AsQueryable().First().Id);
                Assert.AreEqual(users[0].IsBanned, result.AsQueryable().First().IsBanned);
                Assert.AreEqual(users[1].UserName, result.AsQueryable().Last().UserName);
                Assert.AreEqual(users[1].Id, result.AsQueryable().Last().Id);
                Assert.AreEqual(users[1].IsBanned, result.AsQueryable().Last().IsBanned);
            }
        }
    }
}

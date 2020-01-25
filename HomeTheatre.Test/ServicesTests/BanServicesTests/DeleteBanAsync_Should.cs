using HomeTheatre.Data;
using HomeTheatre.Data.DbModels;
using HomeTheatre.Services.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTheatre.Test.ServicesTests.BanServicesTests
{
    [TestClass]
    public class DeleteBanAsync_Should
    {

        [TestMethod]
        public async Task CorrectlyDeleteBan()
        {
            //Arrange
            var options = Utilities.GetOptions(nameof(CorrectlyDeleteBan));
            var testGuid = Guid.NewGuid();
            var user = new User
            {
                Id = testGuid,
                UserName = "Martin",
                IsBanned = true,
                LockoutEnabled = true,
                LockoutEnd = DateTime.UtcNow.AddDays(1)
            };
            var ban = new Ban { HasExpired = false, User = user };

            using (var actContext = new TheatreContext(options))
            {
                //Act
                await actContext.Users.AddAsync(user);
                await actContext.Bans.AddAsync(ban);
                await actContext.SaveChangesAsync();
                var sut = new BanServices(actContext);
                await sut.RemoveBanAsync(testGuid);
                await actContext.SaveChangesAsync();
            }

            using (var assertContext = new TheatreContext(options))
            {
                //Assert
                var user01 = await assertContext.Users.FirstAsync();
                var ban01 = assertContext.Bans
                    .Include(u => u.User)
                    .Where(b => b.User == user)
                    .FirstOrDefault();
                Assert.AreEqual(user.IsBanned, false);
                Assert.AreEqual(ban.HasExpired, true);
                Assert.AreEqual(user.LockoutEnd < DateTime.Now, true);
            }
        }

        [TestMethod]
        public async Task ThrowWhen_BanIsNull()
        {
            //Arrange
            var options = Utilities.GetOptions(nameof(CorrectlyDeleteBan));
            var testGuid = Guid.NewGuid();
            var userTest = new User
            {
                Id = testGuid,
                UserName = "Martin",
                IsBanned = true,
                LockoutEnabled = true,
                LockoutEnd = DateTime.UtcNow.AddDays(1)
            };

            using (var assertContext = new TheatreContext(options))
            {
                //Act & Assert
                await assertContext.Users.AddAsync(userTest);
                await assertContext.SaveChangesAsync();
                var sut = new BanServices(assertContext);
                await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => sut.RemoveBanAsync(testGuid));
            }
        }
    }
}

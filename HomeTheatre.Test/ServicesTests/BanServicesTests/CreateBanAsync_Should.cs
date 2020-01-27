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
    public class CreateBanAsync_Should
    {
        [TestMethod]
        public async Task CreateInstanceOfBan()
        {
            var options = Utilities.GetOptions(nameof(CreateInstanceOfBan));

            var testGuid = Guid.NewGuid();

            var user = new User { Id = testGuid, UserName = "Mariika" };

            using (var actContext = new TheatreContext(options)) 
            {
                var sut = new BanServices(actContext);
                await actContext.Users.AddAsync(user);
                await actContext.SaveChangesAsync();
                await sut.CreateBanAsync(testGuid, "ImproperLanguage", 31);
                await actContext.SaveChangesAsync();
            }

            using (var assertContext = new TheatreContext(options))
            {
                var ban = assertContext.Bans.FirstOrDefault(x=>x.User==user);
                Assert.IsInstanceOfType(ban,typeof(Ban));
            };
        }

        [TestMethod]
        public async Task SetCorrectParams()
        {
            //Arrange
            var options = Utilities.GetOptions(nameof(SetCorrectParams));
            var testGuid = Guid.NewGuid();
            var user = new User { Id = testGuid, UserName = "Mariika" };

            using (var actContext = new TheatreContext(options))
            {
                //Act
                var sut = new BanServices(actContext);
                await actContext.Users.AddAsync(user);
                await actContext.SaveChangesAsync();
                await sut.CreateBanAsync(testGuid, "Improper language", 31);
                await actContext.SaveChangesAsync();
            }

            using (var assertContext = new TheatreContext(options))
            {
                //Assert
                var ban = assertContext.Bans.Include(b => b.User).FirstOrDefault(b => b.User.UserName == "Mariika");
                Assert.AreEqual("Mariika", ban.User.UserName);
                Assert.AreEqual("Improper language", ban.ReasonBanned);
            }
        }
    }
}

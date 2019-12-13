using HomeTheatre.Data;
using HomeTheatre.Data.DbModels;
using HomeTheatre.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HomeTheatre.Test.ServicesTests.TheatreTests
{
    [TestClass]
   public class CreateTheatreAsync_Should
    {
        [TestMethod]
        public async Task ValidTheatre()
        {
            //Arrange
            var options = Utilities.GetOptions(nameof(ValidTheatre));

            var testTheatre = new Theatre()
            {
                Id = Guid.NewGuid(),
                Name = "TestName",
                AboutInfo = "TestAboutInfo",
                Location = "TestLocation",
                Phone="0896663554",
            };
            using (var assertContext = new TheatreContext(options))
            {
                var sut = new TheatreService(assertContext);
                var result = await sut.CreateTheatreAsync(testTheatre);
                Assert.IsInstanceOfType(result, typeof(Theatre));
                Assert.AreEqual(testTheatre.Name,result.Name);
                Assert.AreEqual(testTheatre.AboutInfo,result.AboutInfo);
                Assert.AreEqual(testTheatre.Location,result.Location);
                Assert.AreEqual(testTheatre.Phone, result.Phone);
            }
        }
        [TestMethod]
        public async Task ThrowWhenObjectIsNull()
        {
            var options = Utilities.GetOptions(nameof(ValidTheatre));

            using (var assertContext = new TheatreContext(options))
            {
                var sut = new TheatreService(assertContext);
                await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => sut.CreateTheatreAsync(null));
            }
        }
    }
}

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
    public class GetTheatreAsync_Should
    {
        [TestMethod]
        public async Task ReturnCorrectTheatre()
        {
            var options = Utilities.GetOptions(nameof(ReturnCorrectTheatre));
            var testIdGuid = Guid.NewGuid();
            var testTheatre04 = new Theatre()
            {
                Id = testIdGuid,
                Name = "TestName",
                AboutInfo = "TestAboutInfo",
                Location = "TestLocation",
                Phone = "0896663554",
            };
            using (var assertContext = new TheatreContext(options))
            {
                var sut = new TheatreService(assertContext);
                var result = await sut.GetTheatreAsync(testIdGuid);
                Assert.IsInstanceOfType(result, typeof(Theatre));
                Assert.AreEqual(testTheatre04.Name, result.Name);
                Assert.AreEqual(testTheatre04.AboutInfo, result.AboutInfo);
                Assert.AreEqual(testTheatre04.Location, result.Location);
                Assert.AreEqual(testTheatre04.Phone, result.Phone);
            }
        }

        [TestMethod]
        public async Task ThorwWhenNoTheatreFound()
        {
            var options = Utilities.GetOptions(nameof(ReturnCorrectTheatre));
            var secondId = Guid.NewGuid();
            var testTheatre05 = new Theatre()
            {
                Id = Guid.NewGuid(),
                Name = "TestName",
                AboutInfo = "TestAboutInfo",
                Location = "TestLocation",
                Phone = "0896663554",
            };
            using (var assertContext = new TheatreContext(options))
            {
                await assertContext.Theatres.AddAsync(testTheatre05);
                await assertContext.SaveChangesAsync();
            }
            using (var assertContext = new TheatreContext(options))
            {
                var sut = new TheatreService(assertContext);
                await Assert.ThrowsExceptionAsync<Exception>(() => sut.GetTheatreAsync(secondId));
            }
        }
    }
}

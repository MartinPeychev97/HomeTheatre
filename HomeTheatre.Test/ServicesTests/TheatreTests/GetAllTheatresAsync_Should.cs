using HomeTheatre.Data;
using HomeTheatre.Data.DbModels;
using HomeTheatre.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTheatre.Test.ServicesTests.TheatreTests
{
    [TestClass]
    public class GetAllTheatresAsync_Should
    {
        [TestMethod]
        public async Task ReturnTheatres()
        {
            var options = Utilities.GetOptions(nameof(ReturnTheatres));
            var testId01 = Guid.NewGuid();
            var testId02 = Guid.NewGuid();

            var testTheatre06 = new Theatre()
            {
                Id = testId01,
                Name = "TestName",
                AboutInfo = "TestAboutInfo",
                Location = "TestLocation",
                Phone = "0896663554",
            };
            var testTheatre07 = new Theatre()
            {
                Id = testId02,
                Name = "TestName",
                AboutInfo = "TestAboutInfo",
                Location = "TestLocation",
                Phone = "0896663554",
            };
            var collection = new List<Theatre>
            {
                testTheatre06,
                testTheatre07
            };

            using (var assertContext = new TheatreContext(options))
            {
                await assertContext.Theatres.AddAsync(testTheatre06);
                await assertContext.Theatres.AddAsync(testTheatre07);
                await assertContext.SaveChangesAsync();
            }
            using (var assertContext = new TheatreContext(options))
            {
                var sut = new TheatreService(assertContext);
                var result = await sut.GetAllTheatresAsync();
                Assert.IsInstanceOfType(result, typeof(ICollection<Theatre>));
                Assert.AreEqual(2, result.Count);
                Assert.AreEqual(testTheatre06.Id, result.First().Id);
                Assert.AreEqual(testTheatre06.Name, result.First().Name);
                Assert.AreEqual(testTheatre06.AboutInfo, result.First().AboutInfo);
                Assert.AreEqual(testTheatre06.Location, result.First().Location);
                Assert.AreEqual(testTheatre06.Phone, result.First().Phone);
                Assert.AreEqual(testTheatre07.Id, result.Last().Id);
                Assert.AreEqual(testTheatre07.Name, result.Last().Name);
                Assert.AreEqual(testTheatre07.AboutInfo, result.Last().AboutInfo);
                Assert.AreEqual(testTheatre07.Location, result.Last().Location);
                Assert.AreEqual(testTheatre07.Phone, result.Last().Phone);
            }
        }
        [TestMethod]
        public async Task ThrowWhenTheatresNotFound()
        {
            var options = Utilities.GetOptions(nameof(ReturnTheatres));
            var testTheatre06 = new Theatre()
            {
                Id = Guid.NewGuid(),
                Name = "TestName",
                AboutInfo = "TestAboutInfo",
                Location = "TestLocation",
                Phone = "0896663554",
            };
            using (var assertContext = new TheatreContext(options))
            {
                await assertContext.Theatres.AddAsync(testTheatre06);
                await assertContext.SaveChangesAsync();
            }
            using (var assertContext = new TheatreContext(options))
            {
                var sut = new TheatreService(assertContext);
                await Assert.ThrowsExceptionAsync<Exception>(()=>sut.GetAllTheatresAsync());
            }
        }
    }
}

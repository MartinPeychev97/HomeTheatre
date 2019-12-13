using HomeTheatre.Data;
using HomeTheatre.Data.DbModels;
using HomeTheatre.Services.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HomeTheatre.Test.ServicesTests.TheatreTests
{
    [TestClass]
    public class DeleteTheatreAsync_Should
    {
        [TestMethod]
        public async Task DeleteTheatreTest()
        {
            //Arrange
            var options = Utilities.GetOptions(nameof(DeleteTheatreTest));

            var testTheatre00 = new Theatre()
            {
                Id = Guid.NewGuid(),
                Name = "TestName",
                AboutInfo = "TestAboutInfo",
                Location = "TestLocation",
                Phone = "0896663554",
            };
            using (var assertContext = new TheatreContext(options))
            {
                await assertContext.Theatres.AddAsync(testTheatre00);
                await assertContext.SaveChangesAsync();
                var serviceTest = new TheatreService(assertContext);
                var result = await serviceTest.DeleteTheatreAsync(testTheatre00.Id);
                await assertContext.SaveChangesAsync();
            }
            using (var assertContext = new TheatreContext(options))
            {
                var result = await assertContext.Theatres.FirstAsync();
                Assert.AreEqual(true, result.IsDeleted);
            }
        }
        [TestMethod]
        public async Task ThrowWhenTheatreIsNull()
        {
            //Arrange
            var options = Utilities.GetOptions(nameof(DeleteTheatreTest));

            var testTheatre03 = new Theatre()
            {
                Id = Guid.NewGuid(),
                Name = "TestName",
                AboutInfo = "TestAboutInfo",
                Location = "TestLocation",
                Phone = "0896663554",
            };
            using (var assertContext = new TheatreContext(options))
            {
                var sut = new TheatreService(assertContext);
                await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => sut.DeleteTheatreAsync(testTheatre03.Id));
            }
        }
        [TestMethod]
        public async Task ReturnCorrectTheatre()
        {
            var options = Utilities.GetOptions(nameof(DeleteTheatreTest));

            var testTheatre02 = new Theatre()
            {
                Id = Guid.NewGuid(),
                Name = "TestName",
                AboutInfo = "TestAboutInfo",
                Location = "TestLocation",
                Phone = "0896663554",
            };
            using (var assertContext = new TheatreContext(options))
            {
                await assertContext.Theatres.AddAsync(testTheatre02);
                await assertContext.SaveChangesAsync();
            }
            using (var assertContext = new TheatreContext(options))
            {
                var sut = new TheatreService(assertContext);
                var result = await sut.DeleteTheatreAsync(testTheatre02.Id);
                Assert.IsInstanceOfType(result, typeof(Theatre));
                Assert.AreEqual(testTheatre02.Id, result.Id);
                Assert.AreEqual(testTheatre02.Name, result.Name);
                Assert.AreEqual(testTheatre02.AboutInfo, result.AboutInfo);
                Assert.AreEqual(testTheatre02.Location, result.Location);
                Assert.AreEqual(testTheatre02.Phone, result.Phone);
            }
        }

    }
}

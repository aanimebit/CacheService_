using CacheService_.DatabaseLocal;
using CacheService_.Entities.AdmEntities;
using CacheService_.Services;
using CacheService_.Services.ServiceInterfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Xml.Linq;

namespace CacheService_Test
{
    [TestClass]
    public class AdmUserCacheServiceTest
    {
        private AppDbContext _context;
        private IAdmUserCacheService _admUserCacheService;

        [TestInitialize]
        public void Startup()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "Db")
                .Options;

            _context = new AppDbContext(options);

            DbStartup.GenerateAdmUserCategories(_context);
            DbStartup.GenerateAdmUserResponsobilities(_context);

            _admUserCacheService = new AdmUserCacheService(_context);
        }

        [TestMethod]
        public void AggregateAdmUserTasks()
        {
            int districtAvailable = 1;

            _admUserCacheService.AggregateAdmUserTasks(districtAvailable);

            List<AdmUserTaskCacheEntity> cache = _context.AdmUserTaskCaches.ToList();

            Assert.AreEqual(1, cache[0].UserId);
            Assert.AreEqual(1, cache[0].CategoryId);
            Assert.AreEqual(2, cache[0].TaskId);

            Assert.AreEqual(1, cache[1].UserId);
            Assert.AreEqual(1, cache[1].CategoryId);
            Assert.AreEqual(1, cache[1].TaskId);
        }
    }
}
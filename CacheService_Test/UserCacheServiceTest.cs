using CacheService_.DatabaseLocal;
using CacheService_.Entities.UserEntities;
using CacheService_.Services;
using CacheService_.Services.ServiceInterfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Xml.Linq;

namespace CacheService_Test
{
    [TestClass]
    public class UserCacheServiceTest
    {
        private AppDbContext _context;
        private IUserCacheService<UserTaskCacheEntity> _userCacheService;

        [TestInitialize]
        public void Startup()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "Db")
                .Options;

            _context = new AppDbContext(options);

            DbStartup.GenerateUserCategories(_context);
            DbStartup.GenerateUserTasks(_context);

            _userCacheService = new UserCacheService(_context);
        }

        [TestMethod]
        public void AggregateUserTasks()
        {
            int allTaskAvailable = 1;

            _userCacheService.AggregateUserTasks(allTaskAvailable);

            List<UserTaskCacheEntity> cache = _context.UserTaskCaches.ToList();

            Assert.AreEqual(1, cache[0].UserId);
            Assert.AreEqual(1, cache[0].CategoryId);
            Assert.AreEqual(2, cache[0].TaskId);

            Assert.AreEqual(1, cache[1].UserId);
            Assert.AreEqual(1, cache[1].CategoryId);
            Assert.AreEqual(1, cache[1].TaskId);
        }
    }
}
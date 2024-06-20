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
    public class UserTaskResponsibilityServiceTest
    {
        private AppDbContext _context;
        private IUserTaskResponsibilityService _userTaskResponsibilityService;

        [TestInitialize]
        public void Startup()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "Db")
                .Options;

            _context = new AppDbContext(options);

            DbStartup.GenerateUserCategories(_context);
            DbStartup.GenerateUserTasks(_context);

            _userTaskResponsibilityService = new UserTaskResponsibilityService(_context);
        }

        [TestMethod]
        public void FillUserTaskResponsibilities()
        {
            int districtAvailable = 1;

            _userTaskResponsibilityService.FillUserTaskResponsibilities(districtAvailable);

            List<UserTaskResponsibilityEntity> responsibilities = _context.UserTaskResponsibilities.ToList();

            Assert.AreEqual(5, responsibilities[0].UserId);
            Assert.AreEqual(1, responsibilities[0].TaskId);

            Assert.AreEqual(2, responsibilities[1].UserId);
            Assert.AreEqual(2, responsibilities[1].TaskId);

            Assert.AreEqual(1, responsibilities[2].UserId);
            Assert.AreEqual(1, responsibilities[2].TaskId);

            Assert.AreEqual(1, responsibilities[3].UserId);
            Assert.AreEqual(2, responsibilities[3].TaskId);
        }
    }
}
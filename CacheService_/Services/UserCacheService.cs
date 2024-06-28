using CacheService_.Entities.UserEntities;
using CacheService_.DatabaseLocal;
using CacheService_.Services.ServiceInterfaces;

namespace CacheService_.Services
{
    public class UserCacheService : IUserCacheService<UserTaskCacheEntity>
    {
        readonly AppDbContext _context;
        public UserCacheService(AppDbContext context)
        {
            _context = context;
        }

        public async void AggregateUserTasks(int allTaskAvailable)
        {
            var cache = from categories in _context.UserCategories
                        from tasks in _context.UserTasks
                        where categories.CategoryId == allTaskAvailable
                        select new
                        {
                            TaskId = tasks.Id,
                            categories.UserId,
                            categories.CategoryId
                        };

            foreach (var item in cache)
            {
                var writtenCache = _context.UserTaskCaches.Where(utc => utc.UserId == item.UserId && utc.TaskId == item.TaskId).SingleOrDefault();

                if (writtenCache == null)
                {
                    await _context.UserTaskCaches.AddAsync(new UserTaskCacheEntity
                    {
                        UserId = item.UserId,
                        TaskId = item.TaskId,
                        CategoryId = item.CategoryId
                    });
                }
                else
                {
                    writtenCache.CategoryId = item.CategoryId;
                }

                await _context.SaveChangesAsync();
            }
        }

        public List<UserTaskCacheEntity> GetUserCache()
        {
            return _context.UserTaskCaches.ToList();
        }
    }
}

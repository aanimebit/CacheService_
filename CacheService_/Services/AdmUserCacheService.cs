using CacheService_.Entities.AdmEntities;
using CacheService_.Services.ServiceInterfaces;
using Microsoft.EntityFrameworkCore;
using CacheService_.DatabaseLocal;

namespace CacheService_.Services
{
    public class AdmUserCacheService : IUserCacheService<AdmUserTaskCacheEntity>
    {
        readonly AppDbContext _context;

        public AdmUserCacheService(AppDbContext context)
        {
            _context = context;
        }

        public async void AggregateUserTasks(int districtAvailable)
        {
            var cache = from categories in _context.AdmUserCategories
                        from tasks in _context.AdmUserTasks
                        where categories.CategoryId == districtAvailable
                        select new
                        {
                            TaskId = tasks.Id,
                            categories.UserId,
                            categories.CategoryId
                        };

            foreach (var item in cache)
            {
                var writtenCache = _context.AdmUserTaskCaches.Where(atc => atc.UserId == item.UserId && atc.TaskId == item.TaskId).SingleOrDefault();

                if (writtenCache == null)
                {
                    await _context.AdmUserTaskCaches.AddAsync(new AdmUserTaskCacheEntity
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

        public List<AdmUserTaskCacheEntity> GetUserCache()
        {
            return _context.AdmUserTaskCaches.ToList();
        }
    }
}

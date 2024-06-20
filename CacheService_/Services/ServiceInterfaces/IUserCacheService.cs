using CacheService_.Entities.UserEntities;

namespace CacheService_.Services.ServiceInterfaces
{
    public interface IUserCacheService
    {
        void AggregateUserTasks(int allTaskAvailable);
        List<UserTaskCacheEntity> GetUserCache();
    }
}

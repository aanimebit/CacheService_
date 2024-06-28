using CacheService_.Entities.AdmEntities;
using System.Collections.Generic;

namespace CacheService_.Services.ServiceInterfaces
{
    public interface IUserCacheService<T>
    {
        void AggregateUserTasks(int param);
        List<T> GetUserCache();
    }
}

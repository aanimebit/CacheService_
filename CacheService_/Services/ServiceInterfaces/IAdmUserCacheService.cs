using CacheService_.Entities.AdmEntities;

namespace CacheService_.Services.ServiceInterfaces
{
    public interface IAdmUserCacheService
    {
        void AggregateAdmUserTasks(int districtAvailable);
        List<AdmUserTaskCacheEntity> GetAdmUserCache();
    }
}

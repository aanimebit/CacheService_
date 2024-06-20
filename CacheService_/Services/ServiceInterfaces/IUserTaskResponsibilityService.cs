using CacheService_.Entities.UserEntities;

namespace CacheService_.Services.ServiceInterfaces
{
    public interface IUserTaskResponsibilityService
    {
        void FillUserTaskResponsibilities(int districtAvailable);
        List<UserTaskResponsibilityEntity> GetUserTaskResponsibilities();
    }
}

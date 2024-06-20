using CacheService_.Entities.UserEntities;

namespace CacheService_.Services.ServiceInterfaces
{
    public interface IUserCategoryService
    {
        List<UserCategoryEntity> GetUserCategoriesList();
        void NewUserCategory(UserCategoryEntity userCategory);
    }
}

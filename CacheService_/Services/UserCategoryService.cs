using CacheService_.DatabaseLocal;
using CacheService_.Entities.UserEntities;
using CacheService_.Services.ServiceInterfaces;
using Microsoft.EntityFrameworkCore;

namespace CacheService_.Services
{
    public class UserCategoryService : IUserCategoryService
    {
        readonly AppDbContext _context;

        public UserCategoryService(AppDbContext context)
        {
            _context = context;
        }

        public List<UserCategoryEntity> GetUserCategoriesList()
        {
            return _context.UserCategories.ToList();
        }

        public async void NewUserCategory(UserCategoryEntity userCategory)
        {
            await _context.UserCategories.AddAsync(userCategory);
            await _context.SaveChangesAsync();
        }
    }
}

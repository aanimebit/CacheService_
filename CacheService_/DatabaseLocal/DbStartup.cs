using CacheService_.Entities.UserEntities;
using CacheService_.Entities.AdmEntities;

namespace CacheService_.DatabaseLocal
{
    public class DbStartup
    {
        readonly AppDbContext _context;
        public DbStartup(AppDbContext context)
        {
           context.Database.EnsureCreated();
            _context = context;
        }

        public static async void GenerateUserCategories(AppDbContext context)
        {
            UserCategoryEntity[] categories =
            {
                new UserCategoryEntity{ UserId = 1, CategoryId = 1 },
                new UserCategoryEntity{ UserId = 2, CategoryId = 2 },
                new UserCategoryEntity{ UserId = 3, CategoryId = 3 },
                new UserCategoryEntity{ UserId = 4, CategoryId = 3 },
                new UserCategoryEntity{ UserId = 5, CategoryId = 3 }
            };
            await context.UserCategories.AddRangeAsync(categories);
            await context.SaveChangesAsync();
        }
        public static async void GenerateAdmUserCategories(AppDbContext context)
        {
            AdmUserCategoryEntity[] admCategories =
            {
                new AdmUserCategoryEntity{ UserId = 1, CategoryId = 1 },
                new AdmUserCategoryEntity{ UserId = 2, CategoryId = 2 },
            };
            await context.AdmUserCategories.AddRangeAsync(admCategories);
            await context.SaveChangesAsync();
        }

        public static async void GenerateAdmUserResponsobilities(AppDbContext context)
        {
            AdmUserTaskResponsibilityEntity[] responsobilities =
            {
                new AdmUserTaskResponsibilityEntity{ UserId = 1, TaskId = 1 },
                new AdmUserTaskResponsibilityEntity{ UserId = 2, TaskId = 2 },
            };
            await context.AdmUserTasks.AddRangeAsync(responsobilities);
            await context.SaveChangesAsync();
        }

        public static async void GenerateUserTasks(AppDbContext context)
        {
            UserTaskEntity[] tasks =
            {
                new UserTaskEntity{ ApprovalWith = 1, EscalatedTo = 5 },
                new UserTaskEntity{ ApprovalWith = 1, EscalatedTo = 2 }
            };
            await context.UserTasks.AddRangeAsync(tasks);
            await context.SaveChangesAsync();
        }
    }   
}

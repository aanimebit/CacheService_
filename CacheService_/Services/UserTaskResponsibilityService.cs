using CacheService_.DatabaseLocal;
using CacheService_.Entities.UserEntities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using CacheService_.Services.ServiceInterfaces;

namespace CacheService_.Services
{
    public class UserTaskResponsibilityService : IUserTaskResponsibilityService
    {
        readonly AppDbContext _context;
        public UserTaskResponsibilityService(AppDbContext context)
        {
            _context = context;
        }

        public async void FillUserTaskResponsibilities(int districtAvailable)
        {
            if (_context.UserCategories.Any(uc => uc.CategoryId == districtAvailable))
            {
                var tasks =
                    (_context.UserTasks.Where(ut => ut.ApprovalWith != null).Select(ut => new { TaskId = ut.Id, UserId = ut.ApprovalWith })
                    .Union
                    (_context.UserTasks.Where(ut => ut.EscalatedTo != null).Select(ut => new { TaskId = ut.Id, UserId = ut.EscalatedTo }))).Distinct(); ;

                foreach (var task in tasks)
                {
                    if (!_context.UserTaskResponsibilities.Any(ut => ut.TaskId == task.TaskId && ut.UserId == task.UserId))
                    {
                        _context.UserTaskResponsibilities.Add(new UserTaskResponsibilityEntity
                        {
                            TaskId = task.TaskId,
                            UserId = (long)task.UserId
                        });
                    }
                }

                await _context.SaveChangesAsync();
            }
        }

        public List<UserTaskResponsibilityEntity> GetUserTaskResponsibilities()
        {
            return _context.UserTaskResponsibilities.ToList();
        }
    }
}

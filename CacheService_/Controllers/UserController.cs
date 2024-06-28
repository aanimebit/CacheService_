using CacheService_.Entities.UserEntities;
using CacheService_.DatabaseLocal;
using CacheService_.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Diagnostics;
using CacheService_.Controllers.Errors;
using CacheService_.Services.ServiceInterfaces;

namespace CacheService_.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        #region interfaces and db initialization
        private readonly AppDbContext _context;
        private readonly ILogger<UserController> _logger;
        private readonly IUserTaskResponsibilityService _userTaskResponsibilityService;
        private readonly IUserCacheService<UserTaskCacheEntity> _userCacheService;
        private readonly IUserCategoryService _userCategoryService;

        public UserController(
            AppDbContext context,
            ILogger<UserController> logger,
            IUserTaskResponsibilityService userTaskResponsibilityService,
            IUserCacheService<UserTaskCacheEntity> userCacheService,
            IUserCategoryService userCategoryService)
        {
            _logger = logger;
            _context = context;
            _userTaskResponsibilityService = userTaskResponsibilityService;
            _userCacheService = userCacheService;
            _userCategoryService = userCategoryService;
        }
        #endregion

        [HttpGet("categories")]
        public IEnumerable<UserCategoryEntity> GetUserCategoriesList()
        {
            return _userCategoryService.GetUserCategoriesList();
        }

        [HttpPost("categories/add")]
        public ActionResult NewUserCategory([FromBody] UserCategoryEntity userCategory)
        {
            try
            {
                _userCategoryService.NewUserCategory(userCategory);
                return Ok(200);
            }
            catch (Exception ex)
            {
                return ServerError.InternalServerError(ex.Message);
            }
        }

        [HttpGet("tasks/responsibilities")]
        public List<UserTaskResponsibilityEntity> FillUserTaskResponsibilities()
        {
            return _userTaskResponsibilityService.GetUserTaskResponsibilities();
        }

        [HttpPost("tasks/responsibilitis/fill")]
        public ActionResult FillUserTaskResponsibilities([FromBody] int districtAvailable)
        {
            try
            {
                _userTaskResponsibilityService.FillUserTaskResponsibilities(districtAvailable);
                return Ok(200);
            }
            catch (Exception ex)
            {
                return ServerError.InternalServerError(ex.Message);
            }
        }

        [HttpGet("tasks/cache")]
        public List<UserTaskCacheEntity> GetUserCache()
        {
            return _userCacheService.GetUserCache();
        }

        [HttpPost("tasks/cache/aggregation")]
        public ActionResult AggregateUserResponsibilityTasks([FromBody] int allTaskAvailable)
        {
            try
            {
                _userCacheService.AggregateUserTasks(allTaskAvailable);
                return Ok(200);
            }
            catch (Exception ex) 
            {
                return ServerError.InternalServerError(ex.Message);
            }
        }
    }
}

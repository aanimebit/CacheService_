using CacheService_.Controllers.Errors;
using CacheService_.DatabaseLocal;
using CacheService_.Entities.AdmEntities;
using CacheService_.Services.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace CacheService_.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdmUserController : ControllerBase
    {
        #region interfaces and db initialization
        private readonly AppDbContext _context;
        private readonly ILogger<AdmUserController> _logger;
        private readonly IUserCacheService<AdmUserTaskCacheEntity> _admUserCacheService;

        public AdmUserController(
            AppDbContext context,
            ILogger<AdmUserController> logger,
            IUserCacheService<AdmUserTaskCacheEntity> admUserCacheService)
        {
            _logger = logger;
            _context = context;
            _admUserCacheService = admUserCacheService;
        }
        #endregion

        [HttpGet("tasks/cache")]
        public List<AdmUserTaskCacheEntity> GetAdmUserCache()
        {
            return _admUserCacheService.GetUserCache();
        }

        [HttpPost("tasks/cache/aggregation")]
        public ActionResult AggregateAdmUserTasks([FromBody] int districtAvailable)
        {
            try
            {
                _admUserCacheService.AggregateUserTasks(districtAvailable);
                return Ok(200);
            }
            catch (Exception ex)
            {
                return ServerError.InternalServerError(ex.Message);
            }
        }
    }
}

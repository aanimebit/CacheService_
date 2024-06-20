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
        private readonly IAdmUserCacheService _admUserCacheService;

        public AdmUserController(
            AppDbContext context,
            ILogger<AdmUserController> logger,
            IAdmUserCacheService admUserCacheService)
        {
            _logger = logger;
            _context = context;
            _admUserCacheService = admUserCacheService;
        }
        #endregion

        [HttpGet("tasks/cache")]
        public List<AdmUserTaskCacheEntity> GetAdmUserCache()
        {
            return _admUserCacheService.GetAdmUserCache();
        }

        [HttpPost("tasks/cache/aggregation")]
        public ActionResult AggregateAdmUserTasks([FromBody] int districtAvailable)
        {
            try
            {
                _admUserCacheService.AggregateAdmUserTasks(districtAvailable);
                return Ok(200);
            }
            catch (Exception ex)
            {
                return ServerError.InternalServerError(ex.Message);
            }
        }
    }
}

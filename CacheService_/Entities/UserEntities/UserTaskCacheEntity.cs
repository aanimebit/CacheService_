using Newtonsoft.Json;

namespace CacheService_.Entities.UserEntities
{
    public class UserTaskCacheEntity
    {
        [JsonIgnore]
        public long Id { get; set; }
        public long UserId { get; set; }
        public long TaskId { get; set; }
        public long CategoryId { get; set; }
    }
}

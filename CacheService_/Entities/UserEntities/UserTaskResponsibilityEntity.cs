using Newtonsoft.Json;

namespace CacheService_.Entities.UserEntities
{
    public class UserTaskResponsibilityEntity
    {
        [JsonIgnore]
        public long Id { get; set; }
        public long UserId { get; set; }
        public long TaskId { get; set; }
    }
}

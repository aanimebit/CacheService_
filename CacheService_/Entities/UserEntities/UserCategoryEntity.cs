using System.Text.Json.Serialization;

namespace CacheService_.Entities.UserEntities
{
    public class UserCategoryEntity
    {
        [JsonIgnore]
        public long Id { get; set; }
        public long UserId { get; set; }
        public long CategoryId { get; set; }
    }
}

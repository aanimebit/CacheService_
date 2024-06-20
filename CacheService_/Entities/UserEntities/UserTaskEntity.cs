namespace CacheService_.Entities.UserEntities
{
    public class UserTaskEntity
    {
        public long Id { get; set; }
        public long? ApprovalWith { get; set; }
        public long? EscalatedTo { get; set; }
    }
}

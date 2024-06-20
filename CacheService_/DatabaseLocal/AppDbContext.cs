using CacheService_.Entities.AdmEntities;
using CacheService_.Entities.UserEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;

namespace CacheService_.DatabaseLocal
{
    public class AppDbContext : DbContext
    {
        #region entities creation
        public DbSet<AdmUserTaskResponsibilityEntity> AdmUserTasks { get; set; }
        public DbSet<AdmUserCategoryEntity> AdmUserCategories { get; set; }
        public DbSet<AdmUserTaskCacheEntity> AdmUserTaskCaches { get; set; }
        
        public DbSet<UserCategoryEntity> UserCategories { get; set; }
        public DbSet<UserTaskEntity> UserTasks { get; set; }
        public DbSet<UserTaskCacheEntity> UserTaskCaches { get; set; }
        public DbSet<UserTaskResponsibilityEntity> UserTaskResponsibilities { get; set; }
        #endregion

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region primary keys
            modelBuilder.Entity<AdmUserTaskResponsibilityEntity>().HasKey(aut => aut.Id);
            modelBuilder.Entity<AdmUserCategoryEntity>().HasKey(auc => auc.Id);
            modelBuilder.Entity<AdmUserTaskCacheEntity>().HasKey(atc => atc.Id);
            
            modelBuilder.Entity<UserCategoryEntity>().HasKey(uc => uc.Id);
            modelBuilder.Entity<UserTaskEntity>().HasKey(ut => ut.Id);
            modelBuilder.Entity<UserTaskCacheEntity>().HasKey(utc => utc.Id);
            modelBuilder.Entity<UserTaskResponsibilityEntity>().HasKey(utr => utr.Id);
            #endregion

            #region indexes
            modelBuilder.Entity<UserCategoryEntity>().HasIndex(uc => new { uc.CategoryId, uc.UserId }).IsUnique();
            #endregion
        }
    }
}

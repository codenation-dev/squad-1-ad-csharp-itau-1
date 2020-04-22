using ItaLog.Data.Maps;
using ItaLog.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ItaLog.Data.Context
{
    public class ItaLogContext : DbContext
    {
        public ItaLogContext(DbContextOptions<ItaLogContext> options) : base(options) { }

        public DbSet<ApiUser> ApiUsers { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<Environment> Environments { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<ApiRole> ApiRoles { get; set; }
        public DbSet<ApiUserRole> ApiUserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ApiUserMap());
            modelBuilder.ApplyConfiguration(new LogMap());
            modelBuilder.ApplyConfiguration(new LevelMap());
            modelBuilder.ApplyConfiguration(new EnvironmentMap());
            modelBuilder.ApplyConfiguration(new EventMap());
            modelBuilder.ApplyConfiguration(new ApiRoleMap());
            modelBuilder.ApplyConfiguration(new ApiUserRoleMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}


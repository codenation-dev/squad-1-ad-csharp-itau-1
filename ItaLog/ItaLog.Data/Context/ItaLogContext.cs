using ItaLog.Data.Maps;
using ItaLog.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ItaLog.Data.Context
{
    public class ItaLogContext : DbContext
    {
        public ItaLogContext(DbContextOptions<ItaLogContext> options) : base(options) { }

        public DbSet<ApiUser> ApiUser { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<Environment> Environments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ApiUserMap());
            modelBuilder.ApplyConfiguration(new LogMap());
            modelBuilder.ApplyConfiguration(new LevelMap());
            modelBuilder.ApplyConfiguration(new EnvironmentMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}


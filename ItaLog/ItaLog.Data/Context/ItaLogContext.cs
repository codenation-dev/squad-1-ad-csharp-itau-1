using ItaLog.Data.Maps;
using ItaLog.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ItaLog.Data.Context
{
    public class ItaLogContext : IdentityDbContext
    {
        public ItaLogContext(DbContextOptions<ItaLogContext> options) : base(options) { }

        public DbSet<ApiUser> ApiUser { get; set; }
        public DbSet<Log> Logs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ApiUserMap());
            modelBuilder.ApplyConfiguration(new LogMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}


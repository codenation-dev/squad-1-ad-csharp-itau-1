using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItaLog.Models
{
    public class ErrorLogsDbContext : DbContext
    {
        public ErrorLogsDbContext(DbContextOptions<ErrorLogsDbContext> options) : base(options)
        { 
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Log> Logs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(p => p.Id);
            modelBuilder.Entity<Log>().HasKey(p => p.Id);
        }
    }
}


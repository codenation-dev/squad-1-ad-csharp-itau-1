using ItaLog.Data.Maps;
using ItaLog.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItaLog.Data.Context
{
    public class ItaLogContext : DbContext
    {
        public ItaLogContext(DbContextOptions<ItaLogContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Log> Logs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new LogMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}


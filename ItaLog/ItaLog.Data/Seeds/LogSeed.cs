using ItaLog.Data.Context;
using ItaLog.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItaLog.Data.Seeds
{
    public class LogSeed
    {
        private readonly ItaLogContext _context;

        public LogSeed(ItaLogContext context)
        {
            _context = context;
        }

        public void Populate()
        {
            if (_context.Logs.Any())
                return;

            Log l1 = new Log {  Title = "599 Network connect timeout error", Origin = "216.3.128.12", Archived = false, LevelId = 3, EnvironmentId = 1, ApiUserId = 3 };
            Log l2 = new Log {  Title = "413 Request Entity Too Large", Origin = "158.113.248.85", Archived = false, LevelId = 3, EnvironmentId = 2, ApiUserId = 1 };
            Log l3 = new Log {  Title = "512 Disconnected Operation", Origin = "227.39.42.158", Archived = false, LevelId = 1, EnvironmentId = 2, ApiUserId = 4};
            Log l4 = new Log {  Title = "111 Revalidation Failed", Origin = "240.20.41.59", Archived = false, LevelId = 2, EnvironmentId = 1, ApiUserId = 6 };
            Log l5 = new Log {  Title = "214 Transformation Applied", Origin = "84.18.82.201", Archived = true, LevelId = 2, EnvironmentId = 3, ApiUserId = 2 };
            Log l6 = new Log {  Title = "Removed BreakPoints", Origin = "7.41.110.164", Archived = false, LevelId = 1, EnvironmentId = 2, ApiUserId = 7 };

            _context.Logs.AddRange(l1, l2, l3, l4, l5, l6);
            _context.SaveChanges();
        }
    }
}
 



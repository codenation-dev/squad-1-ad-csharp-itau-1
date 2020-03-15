using ItaLog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItaLog.Repository
{
    public class LogRepository : ILogRepository
    {
        private readonly ErrorLogsDbContext _context;
        public LogRepository(ErrorLogsDbContext context)
        {
            _context = context;
        }

        public void Add(Log log)
        {
            _context.Logs.Add(log);
            _context.SaveChanges();
        }

        public Log FindById(int id)
        {
            return _context.Logs.FirstOrDefault(user => user.Id == id);
        }

        public IEnumerable<Log> GetLogs()
        {
            return _context.Logs.ToList();
        }

        public void Remove(int id)
        {
            var log = _context.Logs.First(log => log.Id == id);
            _context.Logs.Remove(log);
            _context.SaveChanges();
        }

        public void Update(Log log)
        {
            _context.Logs.Update(log);
            _context.SaveChanges();
        }
    }
}

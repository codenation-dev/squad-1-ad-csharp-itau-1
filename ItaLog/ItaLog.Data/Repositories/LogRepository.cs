using ItaLog.Data.Context;
using ItaLog.Domain.Interfaces.Repositories;
using ItaLog.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace ItaLog.Api.Repository
{
    public class LogRepository : ILogRepository
    {
        private readonly ItaLogContext _context;
        public LogRepository(ItaLogContext context)
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
            return _context.Logs.Find(id);
        }

        public IEnumerable<Log> GetAll()
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

        public void Archive(int id)
        {
            var log = FindById(id);
            log.Archive = true;
            _context.SaveChanges();
        }
    }
}

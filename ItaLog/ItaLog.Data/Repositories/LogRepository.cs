using ItaLog.Data.Context;
using ItaLog.Data.Extensions;
using ItaLog.Domain.Interfaces.Repositories;
using ItaLog.Domain.Models;
using Microsoft.EntityFrameworkCore;
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

        public void Archive(int id)
        {
            Log log = _context.Logs.Where(i => i.Id == id).Single();
            log.Archived = true;
            _context.Logs.Update(log);
            _context.SaveChanges();
        }

        public void Add(Log log)
        {
            var logBd = FiendByGrouping(log);

            if (logBd == null)
                _context.Logs.Add(log);
            else
            {
                foreach (var newEvent in log.Events)
                {
                    newEvent.LogId = logBd.Id;
                    _context.Events.Add(newEvent);
                }
            }
            _context.SaveChanges();
        }

        public Log FindById(int id)
        {
            return _context
                .Logs
                .Where(i => i.Id == id)
                .Include(x => x.Level)
                .Include(x => x.Events)
                .Include(x => x.Environment)
                .Single();
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


        private Log FiendByGrouping(Log log)
        {
            return _context
                    .Logs
                    .FirstOrDefault(x =>
                        x.Title.ToLower() == log.Title.ToLower()
                        && x.LevelId == log.LevelId
                        && x.ApiUserId == log.ApiUserId
                        && x.EnvironmentId == log.EnvironmentId
                        && x.Origin == log.Origin
                        && x.Archived == false
                    );
        }

        public Page<Log> GetPage(int pageNumber = 1, int pageLength = 20)
        {
            return _context
                    .Logs
                    .Where(log => log.Archived == false)
                    .Include(x => x.Level)
                    .Include(x => x.Events)
                    .Include(x => x.Environment)
                    .ToPage(pageNumber, pageLength);             
        }
    }
}

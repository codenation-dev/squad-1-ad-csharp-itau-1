using ItaLog.Data.Context;
using ItaLog.Domain.Exceptions;
using ItaLog.Domain.Models;
using ItaLog.Data.Extensions;
using ItaLog.Domain.Interfaces.Repositories;
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

        public int Add(Log log)
        {
            ExistsForeignKey(log);
            var logBd = FiendByGrouping(log);

            if (logBd == null)
            {
                logBd = log;
                _context.Logs.Add(logBd);
            }
            else
            {
                foreach (var newEvent in log.Events)
                {
                    newEvent.LogId = logBd.Id;
                    _context.Events.Add(newEvent);
                }
            }
            _context.SaveChanges();

            return logBd.Id;
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

        //public Page<Log> GetPage(LogFilter logFilter, PageFilter pageFilter)
        //{
        //    int? levelId = logFilter == null ? null : logFilter.LevelId;
        //    string origin = logFilter == null ? null : logFilter.Origin;
        //    string title = logFilter == null ? null : logFilter.Title;

        //    return _context
        //            .Logs
        //            .Where(log => log.Archived == false
        //                && (!levelId.HasValue || log.LevelId == levelId)
        //                && (string.IsNullOrWhiteSpace(origin) || log.Origin.ToLower().Contains(origin))
        //                && (string.IsNullOrWhiteSpace(title) || log.Title.ToLower().Contains(title.ToLower()))
        //            )
        //            .Include(x => x.Level)
        //            .Include(x => x.Events)
        //            .Include(x => x.Environment)                    
        //            .ToPage(pageFilter);             
        //}

        public Page<Log> GetPage(PageFilter pageFilter)
        {
            return _context
                    .Logs
                    .Include(x => x.Level)
                    .Include(x => x.Events)
                    .Include(x => x.Environment)
                    .ToPage(pageFilter);
        }

        private void ExistsForeignKey(Log log)
        {
            if (!(_context.Levels.Any(x => x.Id == log.LevelId)))
            {
                throw new ForeignKeyNotFoundException(nameof(log.LevelId), log.LevelId.ToString());
            }

            if (!(_context.Environments.Any(x => x.Id == log.EnvironmentId)))
            {
                throw new ForeignKeyNotFoundException(nameof(log.EnvironmentId), log.EnvironmentId.ToString());
            }

            if (!(_context.Users.Any(x => x.Id == log.ApiUserId)))
            {
                throw new ForeignKeyNotFoundException(nameof(log.ApiUserId), log.ApiUserId.ToString());
            }
        }
    }
}

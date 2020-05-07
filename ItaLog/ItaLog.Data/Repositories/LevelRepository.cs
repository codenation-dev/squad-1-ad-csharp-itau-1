using ItaLog.Data.Context;
using ItaLog.Data.Extensions;
using ItaLog.Domain.Interfaces.Repositories;
using ItaLog.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace ItaLog.Data.Repositories
{
    public class LevelRepository : ILevelRepository
    {
        private readonly ItaLogContext _context;
        public LevelRepository(ItaLogContext context)
        {
            _context = context;
        }

        public int Add(Level level)
        {
            _context.Levels.Add(level);
            _context.SaveChanges();

            return level.Id;
        }

        public Level FindById(int id)
        {
            return _context.Levels.FirstOrDefault(level => level.Id == id);
        }

        public IEnumerable<Level> GetAll()
        {
            return _context.Levels.ToList();
        }

        public void Remove(int id)
        {
            var level = _context.Levels.First(level => level.Id == id);
            _context.Levels.Remove(level);
            _context.SaveChanges();
        }

        public void Update(Level level)
        {
            _context.Levels.Update(level);
            _context.SaveChanges();
        }

        public Page<Level> GetPage(PageFilter pageFilter)
        {

            return _context
                    .Levels
                    .ToPage(pageFilter);
        }

        public bool ExistsEntity(int id)
        {
            return _context.Levels.Any(x => x.Id == id);
        }
    }
}

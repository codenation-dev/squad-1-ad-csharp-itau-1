using ItaLog.Data.Context;
using ItaLog.Domain.Interfaces.Repositories;
using ItaLog.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace ItaLog.Api.Repository
{
    public class LevelRepository : ILevelRepository
    {
        private readonly ItaLogContext _context;
        public LevelRepository(ItaLogContext context)
        {
            _context = context;
        }

        public void Add(Level level)
        {
            _context.Levels.Add(level);
            _context.SaveChanges();
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
            var user = _context.Levels.First(level => level.Id == id);
            _context.Levels.Remove(user);
            _context.SaveChanges();
        }

        public void Update(Level level)
        {
            _context.Levels.Update(level);
            _context.SaveChanges();
        }
    }
}

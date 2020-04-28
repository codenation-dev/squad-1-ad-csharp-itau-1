using ItaLog.Data.Context;
using ItaLog.Domain.Models;
using System.Linq;

namespace ItaLog.Data.Seed
{
    public class LevelSeed
    {
        private readonly ItaLogContext _context;

        public LevelSeed(ItaLogContext context)
        {
            _context = context;
        }

        public void Populate()
        {
            if (_context.Levels.Any())
                return;

            Level lvl1 = new Level
            {
                Description = "Debug"
            };
            Level lvl2 = new Level
            {
                Description = "Warning"
            };
            Level lvl3 = new Level
            {
                Description = "Error"
            };

            _context.Levels.AddRange(lvl1, lvl2, lvl3);
            _context.SaveChanges();
        }
        //public static Level[] GetData()
        //{
        //    int idValue = 0;
            //return new Level[]
            //{
            //    new Level
            //    {
            //        Id = ++idValue,
            //        Description = "Debug"
            //    },
            //    new Level
            //    {
            //        Id = ++idValue,
            //        Description = "Warning"
            //    },
            //    new Level
            //    {
            //        Id = ++idValue,
            //        Description = "Error"
            //    },
            //};
        //}
    }
}

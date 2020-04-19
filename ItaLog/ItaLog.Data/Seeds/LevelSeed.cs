using ItaLog.Domain.Models;

namespace ItaLog.Data.Seed
{
    public static class LevelSeed
    {
        public static Level[] GetData()
        {
            int idValue = 0;

            return new Level[]
            {
                new Level
                {
                    Id = ++idValue,
                    Description = "Debug"
                },
                new Level
                {
                    Id = ++idValue,
                    Description = "Warning"
                },
                new Level
                {
                    Id = ++idValue,
                    Description = "Error"
                },
            };
        }
    }
}

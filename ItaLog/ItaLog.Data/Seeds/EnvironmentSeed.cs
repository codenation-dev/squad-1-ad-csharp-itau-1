using ItaLog.Domain.Models;

namespace ItaLog.Data.Seed
{
    public static class EnvironmentSeed
    {
        public static Environment[] GetData()
        {
            int idValue = 0;
            return new Environment[]
            {
                new Environment
                {
                    Id = ++idValue,
                    Description = "Production"
                },
                new Environment
                {
                    Id = ++idValue,
                    Description = "Homologation"
                },
                new Environment
                {
                    Id = ++idValue,
                    Description = "Development"
                },
            };
        }
    }
}

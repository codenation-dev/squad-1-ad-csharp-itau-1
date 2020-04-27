using ItaLog.Data.Context;
using ItaLog.Domain.Models;
using System.Linq;

namespace ItaLog.Data.Seed
{
    public class EnvironmentSeed
    {
        private readonly ItaLogContext _context;

        public EnvironmentSeed(ItaLogContext context)
        {
            _context = context;
        }

        public void Populate()
        {
            if (_context.Environments.Any())
                return;

            Environment env1 = new Environment
            {
               // Id = 1,
                Description = "Production"
            };
            Environment env2 = new Environment
            {
                //Id = 2,
                Description = "Homologation"
            };
            Environment env3 = new Environment
            {
               // Id = 3,
                Description = "Development"
            };

            _context.Environments.AddRange(env1, env2, env3);
            _context.SaveChanges();
        }
        //public static Environment[] GetData()
        //{
        //int idValue = 0;
        //    return new Environment[]
        //    {
        //        new Environment
        //        {
        //            Id = ++idValue,
        //            Description = "Production"
        //        },
        //        new Environment
        //        {
        //            Id = ++idValue,
        //            Description = "Homologation"
        //        },
        //        new Environment
        //        {
        //            Id = ++idValue,
        //            Description = "Development"
        //        },
        //    };
        //}
    }
}

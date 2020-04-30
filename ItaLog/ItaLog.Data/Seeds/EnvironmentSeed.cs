using ItaLog.Data.Context;
using ItaLog.Domain.Models;
using System.Linq;

namespace ItaLog.Data.Seeds
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
                Description = "Production"
            };
            Environment env2 = new Environment
            {                
                Description = "Homologation"
            };
            Environment env3 = new Environment
            {               
                Description = "Development"
            };

            _context.Environments.AddRange(env1, env2, env3);
            _context.SaveChanges();
        }
    }
}

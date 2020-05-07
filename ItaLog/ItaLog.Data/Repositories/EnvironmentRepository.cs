using ItaLog.Data.Context;
using ItaLog.Data.Extensions;
using ItaLog.Domain.Interfaces.Repositories;
using ItaLog.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace ItaLog.Data.Repositories
{
    public class EnvironmentRepository : IEnvironmentRepository
    {
        private readonly ItaLogContext _context;
        public EnvironmentRepository(ItaLogContext context)
        {
            _context = context;
        }

        public int Add(Environment environment)
        {
            _context.Environments.Add(environment);
            _context.SaveChanges();
            return environment.Id;
        }

        public Environment FindById(int id)
        {
            return _context.Environments.FirstOrDefault(environment => environment.Id == id);
        }

        public IEnumerable<Environment> GetAll()
        {
            return _context.Environments.ToList();
        }

        public void Remove(int id)
        {
            var environment = _context.Environments.First(environment => environment.Id == id);
            _context.Environments.Remove(environment);
            _context.SaveChanges();
        }

        public void Update(Environment environment)
        {
            _context.Environments.Update(environment);
            _context.SaveChanges();
        }

        public Page<Environment> GetPage(PageFilter pageFilter)
        {

            return _context
                    .Environments
                    .ToPage(pageFilter);
        }

        public bool ExistsEntity(int id)
        {
            return _context.Environments.Any(x => x.Id == id);
        }
    }
}

using ItaLog.Data.Context;
using ItaLog.Domain.Models;
using System.Linq;

namespace ItaLog.Data.Seeds
{
    public class RoleSeed
    {
        private readonly ItaLogContext _context;

        public RoleSeed(ItaLogContext context)
        {
            _context = context;
        }
         
        public void Populate()
        {
            if (_context.Roles.Any())
                return;

            Role r1 = new Role { Name = "User" };
            Role r2 = new Role { Name = "Administrator" };

            _context.Roles.AddRange(r1, r2);
            _context.SaveChanges();
        }

        //public static Role[] GetData()
        //{
        //    int idValue = 0;
        //    return new Role[]
        //    {
        //        new Role { Id = ++idValue, Name = "User" },
        //        new Role { Id = ++idValue, Name = "Administrator" },                
        //    };
        ////}
    }
}

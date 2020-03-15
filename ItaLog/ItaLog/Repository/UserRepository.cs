using ItaLog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItaLog.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ErrorLogsDbContext _context;
        public UserRepository(ErrorLogsDbContext context)
        {
            _context = context;
        }

        public void Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public User FindById(int id)
        {
            return _context.Users.FirstOrDefault(user => user.Id == id); 
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Users.ToList();
        }

        public void Remove(int id)
        {
            var user = _context.Users.First(user => user.Id == id);
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public void Update(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }
    }
}

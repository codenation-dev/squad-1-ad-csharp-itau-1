using ItaLog.Data.Context;
using ItaLog.Data.Extensions;
using ItaLog.Domain.Interfaces.Repositories;
using ItaLog.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ItaLog.Data.Repositories
{
    public class UserRepository : IUserRepository, IDisposable
    {
        private readonly ItaLogContext _context;
        public UserRepository(ItaLogContext context)
        {
            _context = context;
        }

        public User FindById(int id)
        {
            return _context.Users.FirstOrDefault(user => user.Id == id);
        }

        public User FindByName(string name)
        {
            return _context.Users.FirstOrDefault(user => user.Name == name);
        }

        public User FindByEmail(string email)
        {
            return _context.Users.FirstOrDefault(user => user.Email == email);
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public Page<User> GetPage(PageFilter pageFilter)
        {

            return _context
                    .Users
                    .ToPage(pageFilter);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

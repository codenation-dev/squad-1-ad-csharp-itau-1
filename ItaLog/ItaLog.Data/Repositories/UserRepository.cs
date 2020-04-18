using ItaLog.Data.Context;
using ItaLog.Domain.Interfaces.Repositories;
using ItaLog.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace ItaLog.Api.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ItaLogContext _context;
        public UserRepository(ItaLogContext context)
        {
            _context = context;
        }

        public void Add(ApiUser user)
        {
            _context.ApiUser.Add(user);
            _context.SaveChanges();
        }

        public ApiUser FindById(int id)
        {
            return _context.ApiUser.FirstOrDefault(user => user.Id == id);
        }

        public IEnumerable<ApiUser> GetAll()
        {
            return _context.ApiUser.ToList();
        }

        public void Remove(int id)
        {
            var user = _context.ApiUser.First(user => user.Id == id);
            _context.ApiUser.Remove(user);
            _context.SaveChanges();
        }

        public void Update(ApiUser user)
        {
            _context.ApiUser.Update(user);
            _context.SaveChanges();
        }
    }
}

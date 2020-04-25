using ItaLog.Data.Context;
using ItaLog.Domain.Interfaces.Repositories;
using ItaLog.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace ItaLog.Api.Repository
{
    public class ApiUserRepository : IApiUserRepository
    {
        private readonly ItaLogContext _context;
        public ApiUserRepository(ItaLogContext context)
        {
            _context = context;
        }

        public ApiUser FindById(int id)
        {
            return _context.ApiUsers.FirstOrDefault(user => user.Id == id);
        }

        public ApiUser FindByName(string name)
        {
            return _context.ApiUsers.FirstOrDefault(user => user.Name == name);
        }

        public ApiUser FindByEmail(string email)
        {
            return _context.ApiUsers.FirstOrDefault(user => user.Email == email);
        }

        public IEnumerable<ApiUser> GetAll()
        {
            return _context.ApiUsers.ToList();
        }            

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

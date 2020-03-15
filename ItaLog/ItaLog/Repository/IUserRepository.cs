using ItaLog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItaLog.Repository
{
    public interface IUserRepository
    {
        public void Add(User user);

        public User FindById(int id);

        public IEnumerable<User> GetUsers();

        public void Remove(int id);

        public void Update(User user);
    }
}

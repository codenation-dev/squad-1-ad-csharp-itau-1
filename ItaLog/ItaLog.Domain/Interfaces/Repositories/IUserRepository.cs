using ItaLog.Domain.Interfaces.Models;
using ItaLog.Domain.Models;
using System;
using System.Collections.Generic;

namespace ItaLog.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IDisposable
    {
        User FindById(int id);
        User FindByName(string name);
        User FindByEmail(string email);
        IEnumerable<User> GetAll();
        Page<User> GetPage(PageFilter pageFilter);
    }
}

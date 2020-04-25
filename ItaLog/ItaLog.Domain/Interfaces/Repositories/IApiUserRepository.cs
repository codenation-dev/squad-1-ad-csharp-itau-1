using ItaLog.Domain.Interfaces.Models;
using ItaLog.Domain.Models;
using System;
using System.Collections.Generic;

namespace ItaLog.Domain.Interfaces.Repositories
{
    public interface IApiUserRepository : IDisposable
    {
        ApiUser FindById(int id);
        ApiUser FindByName(string name);
        ApiUser FindByEmail(string email);
        IEnumerable<ApiUser> GetAll();
    }
}

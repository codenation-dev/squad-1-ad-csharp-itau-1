using ItaLog.Domain.Models;
using System.Collections.Generic;

namespace ItaLog.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        public void Update(User user);
    }
}

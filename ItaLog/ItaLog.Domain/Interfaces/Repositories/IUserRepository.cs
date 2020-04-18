using ItaLog.Domain.Models;
using System.Collections.Generic;

namespace ItaLog.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IRepositoryBase<ApiUser>
    {
        public void Update(ApiUser user);
    }
}

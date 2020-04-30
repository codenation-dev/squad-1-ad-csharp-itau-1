using ItaLog.Domain.Models;
using System.Collections.Generic;

namespace ItaLog.Domain.Interfaces.Repositories
{
    public interface IEnvironmentRepository : IRepositoryBase<Environment>
    {
        public Page<Environment> GetPage(PageFilter pageFilter);
    }
}

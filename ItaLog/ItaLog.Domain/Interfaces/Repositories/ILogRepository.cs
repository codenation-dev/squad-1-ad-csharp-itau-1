using ItaLog.Domain.Models;
using System.Collections.Generic;

namespace ItaLog.Domain.Interfaces.Repositories
{
    public interface ILogRepository : IRepositoryBase<Log>, IPageRepository<Log>
    {
        public void Archive(int id);
    }
}

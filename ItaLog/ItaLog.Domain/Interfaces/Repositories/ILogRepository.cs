using ItaLog.Domain.Models;
using System.Collections.Generic;

namespace ItaLog.Domain.Interfaces.Repositories
{
    public interface ILogRepository : IRepositoryBase<Log>, ILogPage
    {
        public void Archive(int id);
    }
}

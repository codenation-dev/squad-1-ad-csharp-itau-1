using ItaLog.Domain.Models;
using System.Collections.Generic;

namespace ItaLog.Domain.Interfaces.Repositories
{
    public interface ILogRepository : IRepositoryBase<Log>
    {
        public void Archive(int id);
        //public Page<Log> GetPage(LogFilter logFilter, PageFilter pageFilter);
        public Page<Log> GetPage(PageFilter pageFilter);
    }
}

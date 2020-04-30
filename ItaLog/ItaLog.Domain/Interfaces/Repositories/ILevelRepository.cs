using ItaLog.Domain.Models;
using System.Collections.Generic;

namespace ItaLog.Domain.Interfaces.Repositories
{
    public interface ILevelRepository : IRepositoryBase<Level>
    {
        public Page<Level> GetPage(PageFilter pageFilter);
    }
}

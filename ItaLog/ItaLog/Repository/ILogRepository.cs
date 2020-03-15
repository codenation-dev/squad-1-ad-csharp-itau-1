using ItaLog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItaLog.Repository
{
    public interface ILogRepository
    {
        public void Add(Log log);

        public Log FindById(int id);

        public IEnumerable<Log> GetLogs();

        public void Remove(int id);

        public void Update(Log log);
    }
}

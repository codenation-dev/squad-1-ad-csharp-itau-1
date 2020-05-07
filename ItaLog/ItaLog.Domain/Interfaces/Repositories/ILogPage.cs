using ItaLog.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItaLog.Domain.Interfaces.Repositories
{
    public interface ILogPage
    {
        public Page<Log> GetPage(LogFilter logFilter, PageFilter pageFilter, string sortingProperty);
    }
}

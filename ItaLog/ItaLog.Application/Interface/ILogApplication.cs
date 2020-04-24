using ItaLog.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItaLog.Application.Interface
{
    public interface ILogApplication
    {
        IEnumerable<LogItemPageViewModel> GetAllNotArchived();
        void Add(LogEventViewModel entity);
        LogViewModel FindById(int id);
        void Archive(int id);
        void Remove(int id);
    }
}

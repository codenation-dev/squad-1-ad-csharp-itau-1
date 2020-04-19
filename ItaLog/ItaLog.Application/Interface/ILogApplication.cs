using ItaLog.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItaLog.Application.Interface
{
    public interface ILogApplication
    {
        IEnumerable<LogViewModel> GetAll();
        void Add(LogViewModel entity);
        LogViewModel FindById(int id);
        void Remove(int id);
    }
}

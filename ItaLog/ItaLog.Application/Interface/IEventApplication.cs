using ItaLog.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItaLog.Application.Interface
{
    public interface IEventApplication
    {
        IEnumerable<EventViewModel> GetAll();
        void Add(EventViewModel entity);
        void Archive(int id);
        EventViewModel FindById(int id);
        void Remove(int id);
    }
}

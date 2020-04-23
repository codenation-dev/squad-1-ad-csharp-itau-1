using ItaLog.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItaLog.Application.Interface
{
    public interface IEnvironmentApplication
    {
        void Add(EnvironmentViewModel entity);
        void Update(EnvironmentViewModel entity);
        void Remove(int id);
        EnvironmentViewModel FindById(int id);
        IEnumerable<EnvironmentViewModel> GetAll();
    }
}

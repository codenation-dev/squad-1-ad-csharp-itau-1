using ItaLog.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItaLog.Application.Interface
{
    public interface ILevelApplication
    {
        void Add(LevelViewModel entity);
        void Update(LevelViewModel entity);
        void Remove(int id);
        LevelViewModel FindById(int id);
        IEnumerable<LevelViewModel> GetAll();
    }
}

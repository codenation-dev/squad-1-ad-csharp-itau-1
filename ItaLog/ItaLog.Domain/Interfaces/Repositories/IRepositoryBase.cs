using ItaLog.Domain.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItaLog.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<T> where T : class , IEntity
    {
        public void Add(T entity);

        public T FindById(int id);

        public IEnumerable<T> GetAll();

        public void Remove(int id);
    }
}

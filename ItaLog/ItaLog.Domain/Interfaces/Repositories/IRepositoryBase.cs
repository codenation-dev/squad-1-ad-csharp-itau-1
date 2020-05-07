using ItaLog.Domain.Interfaces.Models;
using System.Collections.Generic;

namespace ItaLog.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<T> where T : class , IEntity
    {
        public int Add(T entity);
        public void Update(T entity);

        public T FindById(int id);

        public IEnumerable<T> GetAll();

        public void Remove(int id);

        public bool ExistsEntity(int id);
    }
}

using ItaLog.Data.Context;
using ItaLog.Domain.Interfaces.Repositories;
using ItaLog.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItaLog.Data.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly ItaLogContext _context;
        public EventRepository(ItaLogContext context)
        {
            _context = context;
        }

        public void Add(Event entity)
        {
            throw new NotImplementedException();
        }

        public Event FindById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Event> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Event entity)
        {
            throw new NotImplementedException();
        }

        public void Archive(int id)
        {
            var log = FindById(id);
            log.Archived = true;
            _context.SaveChanges();
        }
    }
}

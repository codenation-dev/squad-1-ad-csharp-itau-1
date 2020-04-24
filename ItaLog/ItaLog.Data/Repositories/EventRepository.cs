using ItaLog.Data.Context;
using ItaLog.Domain.Interfaces.Repositories;
using ItaLog.Domain.Models;
using System.Linq;
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

        public void Add(Event eventLog)
        {
            _context.Events.Add(eventLog);
            _context.SaveChanges();
        }
        
        public Event FindById(int id)
        {
            return _context.Events.FirstOrDefault(eventLog => eventLog.Id == id);
        }

        public IEnumerable<Event> GetAll()
        {
            return _context.Events.ToList();
        }

        public void Remove(int id)
        {
            var eventLog = _context.Events.First(eventLog => eventLog.Id == id);
            _context.Events.Remove(eventLog);
            _context.SaveChanges();
        }

        public void Update(Event eventLog)
        {
            _context.Events.Update(eventLog);
            _context.SaveChanges();
        }
    }
}

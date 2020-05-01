using ItaLog.Domain.Interfaces.Models;
using System.Collections.Generic;

namespace ItaLog.Domain.Models
{
    public class Log : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Origin { get; set; }
        public bool Archived { get; set; }
        public int EventsCount { get; set; }

        public int LevelId { get; set; }
        public Level Level { get; set; }

        public int EnvironmentId { get; set; }
        public Environment Environment { get; set; }

        public int ApiUserId { get; set; }
        public User ApiUser { get; set; }

        public IEnumerable<Event> Events { get; set; }
    }
}

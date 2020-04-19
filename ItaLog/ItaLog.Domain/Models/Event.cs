using ItaLog.Domain.Interfaces.Models;
using System;

namespace ItaLog.Domain.Models
{
    public class Event : IEntity
    {
        public int Id { get; set; }
        public DateTime ErrorDate { get; set; }
        public string Origin { get; set; }
        public bool Archived { get; set; }

        public int LogId { get; set; }
        public Log Log { get; set; }

        public int EnvironmentId { get; set; }
        public Environment Environment { get; set; }
    }
}

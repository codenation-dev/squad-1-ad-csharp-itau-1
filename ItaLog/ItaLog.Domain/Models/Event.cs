using ItaLog.Domain.Interfaces.Models;
using System;

namespace ItaLog.Domain.Models
{
    public class Event : IEntity
    {
        public int Id { get; set; }
        public string Detail { get; set; }
        public DateTime ErrorDate { get; set; }
        
        public int LogId { get; set; }
        public Log Log { get; set; }

    }
}

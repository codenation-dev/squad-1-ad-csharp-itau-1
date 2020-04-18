using ItaLog.Domain.Enums;
using ItaLog.Domain.Interfaces.Models;
using System;

namespace ItaLog.Domain.Models
{
    public class Log : IEntity
    {
        public int Id { get; set; }

        public int Event { get; set; }

        public string Title { get; set; }

        public string Detail { get; set; }

        public bool Archive { get; set; }

        public DateTime DateError { get; set; }

        public int UserId { get; set; }

        public ApiUser User { get; set; }

        public string Origin { get; set; }

        public Enums.Environment Environment { get; set; }

        public Level Level { get; set; }
    }
}

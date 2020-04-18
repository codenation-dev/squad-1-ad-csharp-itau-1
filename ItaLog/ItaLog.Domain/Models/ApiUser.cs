using ItaLog.Domain.Interfaces.Models;
using System;
using System.Collections.Generic;

namespace ItaLog.Domain.Models
{
    public class ApiUser : IEntity
    {
        public int Id { get; set; }

        public Guid Token { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
        public string Role { get; set; }

        public IEnumerable<Log> Logs { get; set; }
    }
}

using ItaLog.Domain.Interfaces.Models;
using System.Collections.Generic;

namespace ItaLog.Domain.Models
{
    public class Role : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<UserRole> UserRoles { get; set; }
    }
}

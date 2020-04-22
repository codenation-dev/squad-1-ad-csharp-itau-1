using ItaLog.Domain.Interfaces.Models;
using System.Collections.Generic;

namespace ItaLog.Domain.Models
{
    public class ApiRole : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<ApiUserRole> UserRoles { get; set; }
    }
}

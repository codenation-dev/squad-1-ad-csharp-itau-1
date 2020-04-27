using ItaLog.Domain.Interfaces.Models;

namespace ItaLog.Domain.Models
{
    public class UserRole : IEntity
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}

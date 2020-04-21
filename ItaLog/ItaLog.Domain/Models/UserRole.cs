using ItaLog.Domain.Interfaces.Models;

namespace ItaLog.Domain.Models
{
    public class UserRole : IEntity
    {
        public int Id { get; set; }

        public int ApiUserId { get; set; }
        public ApiUser ApiUser { get; set; }

        public int ApiRoleId { get; set; }
        public ApiRole ApiRole { get; set; }
    }
}

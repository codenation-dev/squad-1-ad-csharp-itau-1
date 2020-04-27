using System;

namespace ItaLog.Application.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public Guid UserToken { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}

using System;

namespace ItaLog.Application.ViewModels
{
    public class ApiUserViewModel
    {
        public int Id { get; set; }

        public Guid UserToken { get; set; }

        public string Name { get; set; }
        public string UserName { get; set; }

        public string Email { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}

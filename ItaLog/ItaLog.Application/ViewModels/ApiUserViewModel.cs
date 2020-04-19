using System;
using System.Collections.Generic;
using System.Text;

namespace ItaLog.Application.ViewModels
{
    public class ApiUserViewModel
    {
        public int Id { get; set; }

        public Guid Token { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
        public string Role { get; set; }
    }
}

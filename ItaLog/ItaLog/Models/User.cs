using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ItaLog.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; } 

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}

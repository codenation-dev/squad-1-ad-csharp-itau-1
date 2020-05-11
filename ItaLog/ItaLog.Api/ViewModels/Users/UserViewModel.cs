using System;
using System.ComponentModel.DataAnnotations;

namespace ItaLog.Api.ViewModels.Users
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public Guid UserToken { get; set; }
        [Required(ErrorMessage ="Name is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}

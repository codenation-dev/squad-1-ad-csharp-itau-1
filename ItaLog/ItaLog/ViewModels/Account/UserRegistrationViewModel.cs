using System.ComponentModel.DataAnnotations;

namespace ItaLog.Application.ViewModels.Account
{
    public class UserRegistrationViewModel
    {
        [Required(ErrorMessage = "The {0} field is mandatory")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        public string Name { get; set; }

        [Required(ErrorMessage = "The {0} field is mandatory")]
        [EmailAddress(ErrorMessage = "The field {0} is in an invalid format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The {0} field is mandatory")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        //[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        //public string ConfirmPassword { get; set; }
    }
}

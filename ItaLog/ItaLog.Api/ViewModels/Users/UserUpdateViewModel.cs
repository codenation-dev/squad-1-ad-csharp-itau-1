using System.ComponentModel.DataAnnotations;

namespace ItaLog.Api.ViewModels.Users
{
    public class UserUpdateViewModel
    {
        [Required(ErrorMessage = "The {0} field is mandatory")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        public string Name { get; set; }

        [Required(ErrorMessage = "The {0} field is mandatory")]
        [EmailAddress(ErrorMessage = "The field {0} is in an invalid format")]
        public string NewEmail { get; set; }
    }
}

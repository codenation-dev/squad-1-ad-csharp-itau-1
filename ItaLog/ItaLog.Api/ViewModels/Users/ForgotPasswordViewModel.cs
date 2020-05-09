using System.ComponentModel.DataAnnotations;

namespace ItaLog.Api.ViewModels.Users
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}

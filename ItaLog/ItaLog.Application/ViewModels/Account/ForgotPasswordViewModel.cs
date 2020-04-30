using System.ComponentModel.DataAnnotations;

namespace ItaLog.Application.ViewModels.Account
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}

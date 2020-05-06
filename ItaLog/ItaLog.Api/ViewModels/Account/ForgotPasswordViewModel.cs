using System.ComponentModel.DataAnnotations;

namespace ItaLog.Api.ViewModels.Account
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}

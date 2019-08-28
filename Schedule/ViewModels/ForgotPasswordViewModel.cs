using System.ComponentModel.DataAnnotations;

namespace Schedule.ViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}

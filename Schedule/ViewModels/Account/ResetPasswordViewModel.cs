using System.ComponentModel.DataAnnotations;

namespace Schedule.ViewModels.Account
{
    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Password length should be more than 6", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Oooops, inputed passwords are different")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }
}

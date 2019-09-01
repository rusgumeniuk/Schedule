using System.ComponentModel.DataAnnotations;

namespace Schedule.ViewModels.Account
{
    public class LoginViewModel
    {
        [Required]     
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]        
        public string Password { get; set; }

        [Display(Name = "Remember?")]
        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }
    }
}

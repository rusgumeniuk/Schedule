using System.ComponentModel.DataAnnotations;

namespace Schedule.ViewModels
{
    public class RegisterViewModel
    {
        [Required]        
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]        
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Oooops, inputed passwords are different")]
        [DataType(DataType.Password)]
        [Display(Name = "Repeat password")]
        public string PasswordConfirm { get; set; }
    }
}

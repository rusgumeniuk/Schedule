using System.ComponentModel.DataAnnotations;

namespace Schedule.ViewModels
{
    public class GroupFindViewModel
    {
        [Required(ErrorMessage = "Невірна назва групи!\r\nБудь ласка виберіть групу зі списку або введіть повну назву.")]
        [StringLength(8, MinimumLength = 4, ErrorMessage = "Введене має недопустиму довжину")]
        public string SelectedGroup { get; set; }
    }
}

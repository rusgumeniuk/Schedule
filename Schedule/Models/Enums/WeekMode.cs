using System.ComponentModel.DataAnnotations;

namespace Schedule.Models.Enums
{
    public enum WeekMode : byte
    {
        Both,
        [Display(Name = "I тиждень")]
        First,
        [Display(Name = "II тиждень")]
        Second,
    }
}

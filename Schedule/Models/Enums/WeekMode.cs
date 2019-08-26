using System.ComponentModel.DataAnnotations;

namespace Schedule.Models.Enums
{
    public enum WeekMode : byte
    {
        Both = 0,
        [Display(Name = "I тиждень")]
        First = 1,
        [Display(Name = "II тиждень")]
        Second = 2,
    }
}

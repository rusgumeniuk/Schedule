using System.ComponentModel.DataAnnotations;

namespace Schedule.Models.Enums
{
    public enum Rate : byte
    {
        [Display(Name = "Unknown")]
        Undefined,        
        Bad,
        [Display(Name = "Not good")]
        NotGood,
        Normal,
        Good,
        [Display(Name = "Very well")]
        VeryWell
    }
}

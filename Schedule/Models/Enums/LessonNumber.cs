using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Schedule.Models.Enums
{
    public enum LessonNumber : byte
    {
        [Display(Name = "0")]
        Zero,
        [Display(Name = "1")]
        First,
        [Display(Name = "2")]
        Second,
        [Display(Name = "3")]
        Third,
        [Display(Name = "4")]
        Fourth,
        [Display(Name = "5")]
        Fifth
    }
}

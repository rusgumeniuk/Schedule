using Schedule.Models.Enums;
using Schedule.Models.JsonHelpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Schedule.ViewModels
{
    public class GroupScheduleViewModel
    {
        public ResponseGroupData Group { get; set; }
        public IEnumerable<ResponseLessonDataForGroup> Lessons { get; set; }
        public IEnumerable<DayOfWeek> DaysOfWeeks { get; } = Enum.GetValues(typeof(DayOfWeek)).Cast<DayOfWeek>();
        public IEnumerable<LessonNumber> LessonNumbers { get; } = Enum.GetValues(typeof(LessonNumber)).Cast<LessonNumber>(); 
    }
}

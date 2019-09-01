using Schedule.Models.Enums;
using Schedule.Models.JsonHelpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Schedule.ViewModels.Schedule
{
    public class TeacherScheduleViewModel
    {
        public ResponseTeacherData Teacher { get; set; }
        public IEnumerable<ResponseLessonDataForTeacher> Lessons { get; set; }
        public IEnumerable<DayOfWeek> DaysOfWeeks { get; } = Enum.GetValues(typeof(DayOfWeek)).Cast<DayOfWeek>();
        public IEnumerable<LessonNumber> LessonNumbers { get; } = Enum.GetValues(typeof(LessonNumber)).Cast<LessonNumber>();
    }
}

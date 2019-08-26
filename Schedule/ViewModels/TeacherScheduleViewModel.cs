using Schedule.Models.JsonHelpers;
using System.Collections.Generic;

namespace Schedule.ViewModels
{
    public class TeacherScheduleViewModel
    {
        public ResponseTeacherData Teacher { get; set; }
        public IEnumerable<ResponseLessonDataForTeacher> Lessons { get; set; }
    }
}

using Schedule.Models;
using Schedule.Models.Enums;
using Schedule.Models.JsonHelpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Schedule.ViewModels.StudyingProcess
{
    public class LessonFeedbackViewModel
    {
        public User CurrentUser { get; set; }
        public ResponseLessonData Lesson { get; set; }
        public IEnumerable<LessonFeedback> LessonFeedbacks { get; set; }
        public IEnumerable<Rate> Rates { get; } = Enum.GetValues(typeof(Rate)).Cast<Rate>().TakeLast(5);
    }
}

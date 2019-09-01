using Schedule.Models.Enums;

namespace Schedule.ViewModels.StudyingProcess
{
    public class LeaveTeacherFeedbackViewModel
    {
        public string TeacherName { get; set; }
        public Rate Rate { get; set; }
        public string Feedback { get; set; }
        public bool IsAnonymus { get; set; }
    }
}

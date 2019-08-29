using Schedule.Models;
using Schedule.Models.Enums;
using Schedule.Models.JsonHelpers;

namespace Schedule.ViewModels
{
    public class LeaveTeacherFeedbackViewModel
    {        
        public string TeacherName { get; set; }
        public Rate Rate { get; set; }
        public string Feedback { get; set; }
        public bool IsAnonymus { get; set; }
    }
}

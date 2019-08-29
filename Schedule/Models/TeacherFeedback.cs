using Schedule.Models.Enums;
using Schedule.Models.JsonHelpers;

namespace Schedule.Models
{
    public class TeacherFeedback
    {
        public User User { get; set; }
        public ResponseTeacherData Teacher { get; set; }
        public string Description { get; set; }
        public Rate Rate { get; set; } = Rate.Undefined;
    }
}

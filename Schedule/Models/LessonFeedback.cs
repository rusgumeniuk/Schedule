using Schedule.Models.Enums;
using Schedule.Models.JsonHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schedule.Models
{
    public class LessonFeedback
    {
        public ResponseLessonData Lesson { get; set; }
        public User User { get; set; }
        public string Description { get; set; }
        public Rate Rate { get; set; } = Rate.Undefined;
    }
}

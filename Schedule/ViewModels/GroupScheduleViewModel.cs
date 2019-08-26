using Schedule.Models.JsonHelpers;
using System.Collections.Generic;

namespace Schedule.ViewModels
{
    public class GroupScheduleViewModel
    {
        public ResponseGroupData Group { get; set; }
        public IEnumerable<ResponseLessonDataForGroup> Lessons { get; set; }
    }
}

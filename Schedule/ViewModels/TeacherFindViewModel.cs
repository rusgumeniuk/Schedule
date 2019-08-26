using Schedule.Models.JsonHelpers;
using System.Collections.Generic;

namespace Schedule.ViewModels
{
    public class TeacherFindViewModel
    {
        public IEnumerable<ResponseTeacherData> Teachers { get; set; }
    }
}

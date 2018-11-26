using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schedule.Models
{
    public static class ScheduleFormatter
    {
        public static IEnumerable<Lesson> SortLessons(IEnumerable<Lesson> lessons)
        {
            Array.Sort(lessons.ToArray(), new LessonComparer());
            return lessons;
        }
    }
}

using Schedule.Models.Enums;
using System;
using System.Collections.Generic;

namespace Schedule.Models
{
    public class Lesson : Base
    {
        public LessonNumber LessonNumber { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public WeekMode WeekMode { get; set; }
        public LessonType LessonType { get; set; }

        public Room Room { get; set; }
        public Subject Subject { get; set; }
        public Teacher Teacher { get; set; }
        public Group Group { get; set; }

        private Lesson() { }
        public Lesson(Subject subject, Teacher teacher, Group group, Room room) : base()
        {
            this.Subject = subject;
            this.Teacher = teacher;
            this.Group = group;
            this.Room = room;

            this.WeekMode = WeekMode.Both;
            this.DayOfWeek = DayOfWeek.Monday;
            this.LessonNumber = LessonNumber.First;
            this.LessonType = LessonType.Lecture;
        }
        public Lesson(Subject subject, Teacher teacher, Group group, Room room,
            WeekMode weekMode, DayOfWeek dayOfWeek, LessonNumber lessonNumber, LessonType lessonType) : this(subject, teacher, group, room)
        {
            this.WeekMode = weekMode;
            this.DayOfWeek = dayOfWeek;
            this.LessonNumber = lessonNumber;
            this.LessonType = lessonType;
        }
    }

    public class LessonComparer : IComparer<Lesson>
    {
        public int Compare(Lesson x, Lesson y)
        {
            if (x.DayOfWeek > y.DayOfWeek)
                return 1;
            else if (x.DayOfWeek < y.DayOfWeek)
                return -1;
            else
            {
                if (x.LessonNumber > y.LessonNumber)
                    return 1;
                else if (x.LessonNumber < y.LessonNumber)
                    return -1;
                else return 0;
            }
        }
    }
}

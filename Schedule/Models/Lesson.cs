using Schedule.Models.Enums;
using System;
using System.Collections.Generic;

namespace Schedule.Models
{
    public class Lesson : Base<Lesson>
    {
        public readonly LessonNumber LessonNumber;
        public readonly DayOfWeek DayOfWeek;
        public readonly WeekMode WeekMode;
        public readonly LessonType LessonType;

        public readonly Guid RoomId;
        public readonly Guid SubjectId;
        public readonly Guid GroupId;
        public readonly Guid TeacherId;

        public Subject Subject
        {
            get
            {
                foreach (var subject in Subject.Items)
                {
                    if (subject.Key == this.SubjectId)
                    {
                        return subject.Value;
                    }
                }
                Items.Remove(Id);
                throw new ArgumentException($"Wrong ID! We should delete this connection, sorry");
            }
        }
        public Teacher Teacher
        {
            get
            {
                foreach (var teacher in Teacher.Items)
                {
                    if (teacher.Key == this.TeacherId)
                    {
                        return teacher.Value;
                    }
                }
                Items.Remove(Id);
                throw new ArgumentException($"Wrong ID! We should delete this connection, sorry");
            }
        }
        public Group Group
        {
            get
            {
                foreach (var group in Group.Items)
                {
                    if (group.Key == this.GroupId)
                    {
                        return group.Value;
                    }
                }
                Items.Remove(Id);
                throw new ArgumentException($"Wrong ID! We should delete this connection, sorry");
            }
        }

        public Lesson(Guid subjectId, Guid teacherId, Guid groupId, Guid roomId) : base()
        {
            this.SubjectId = subjectId;
            this.TeacherId = teacherId;
            this.GroupId = groupId;
            this.RoomId = roomId;

            this.WeekMode = WeekMode.Both;
            this.DayOfWeek = DayOfWeek.Monday;
            this.LessonNumber = LessonNumber.First;
            this.LessonType = LessonType.Lecture;            
        }
        public Lesson(Guid subjectId, Guid teacherId, Guid groupId, Guid roomId,
            WeekMode weekMode, DayOfWeek dayOfWeek, LessonNumber lessonNumber, LessonType lessonType) : this(subjectId, teacherId, groupId, roomId)
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

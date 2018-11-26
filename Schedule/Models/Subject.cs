﻿using System.Collections.Generic;

namespace Schedule.Models
{
    public class Subject : Entity<Subject>
    {
        public IEnumerable<Group> Groups
        {
            get
            {
                List<Group> res = new List<Group>();
                foreach (var item in Lesson.Items.Values)
                {
                    if (item.SubjectId == Id)
                    {
                        res.Add(item.Group);
                    }
                }
                return res;
            }
        }
        public IEnumerable<Teacher> Teachers
        {
            get
            {
                List<Teacher> res = new List<Teacher>();
                foreach (var item in Lesson.Items.Values)
                {
                    if (item.SubjectId == Id)
                    {
                        res.Add(item.Teacher);
                    }
                }
                return res;
            }
        }
        public IEnumerable<Lesson> Lessons
        {
            get
            {
                List<Lesson> lessons = new List<Lesson>();
                foreach (var lesson in Lesson.Items.Values)
                {
                    if (lesson.SubjectId == Id)
                        lessons.Add(lesson);
                }
                return lessons;
            }
        }
    }
}

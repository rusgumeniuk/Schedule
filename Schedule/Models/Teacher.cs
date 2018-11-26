﻿using System.Collections.Generic;

namespace Schedule.Models
{
    public class Teacher : Entity<Teacher>
    {
        public IEnumerable<Subject> Subjects
        {
            get
            {
                List<Subject> res = new List<Subject>();
                foreach (var item in Lesson.Items.Values)
                {
                    if (item.TeacherId == Id)
                    {
                        res.Add(item.Subject);
                    }
                }
                return res;
            }
        }
        public IEnumerable<Group> Groups
        {
            get
            {
                List<Group> res = new List<Group>();
                foreach (var item in Lesson.Items.Values)
                {
                    if (item.TeacherId == Id)
                    {
                        res.Add(item.Group);
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
                    if (lesson.TeacherId == Id)
                        lessons.Add(lesson);
                }
                return lessons;
            }
        }
    }
}

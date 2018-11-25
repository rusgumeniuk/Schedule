using System.Collections.Generic;

namespace Schedule.Models
{
    public class Group : Entity<Group>
    {
        public IEnumerable<Teacher> Teachers
        {
            get
            {
                List<Teacher> res = new List<Teacher>();
                foreach (var item in Lesson.Items.Values)
                {
                    if (item.Group == this)
                    {
                        res.Add(item.Teacher);
                    }
                }
                return res;
            }
        }
        public IEnumerable<Subject> Subjects
        {
            get
            {
                List<Subject> res = new List<Subject>();
                foreach (var item in Lesson.Items.Values)
                {
                    if (item.Group == this)
                    {
                        res.Add(item.Subject);
                    }
                }

                return res;
            }
        }
    }
}

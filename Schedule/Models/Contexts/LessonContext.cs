using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schedule.Models.Contexts
{
    public class LessonContext : DbContext
    {
        public DbSet<Lesson> Lessons { get; set; }
        public LessonContext(DbContextOptions<BuildContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}

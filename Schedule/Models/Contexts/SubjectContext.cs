using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schedule.Models.Contexts
{
    public class SubjectContext : DbContext
    {
        public DbSet<Subject> Subjects { get; set; }
        public SubjectContext(DbContextOptions<BuildContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schedule.Models.Contexts
{
    public class BuildContext : DbContext
    {
        public DbSet<Build> Builds { get; set; }
        public BuildContext(DbContextOptions<BuildContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}

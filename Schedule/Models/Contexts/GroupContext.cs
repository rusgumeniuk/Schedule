using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schedule.Models.Contexts
{
    public class GroupContext : DbContext
    {
        public DbSet<Group> Groups { get; set; }
        public GroupContext(DbContextOptions<BuildContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}

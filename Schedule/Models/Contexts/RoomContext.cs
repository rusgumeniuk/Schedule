using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schedule.Models.Contexts
{
    public class RoomContext : DbContext
    {
        public DbSet<Room> Rooms { get; set; }
        public RoomContext(DbContextOptions<BuildContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}

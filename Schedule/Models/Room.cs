using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schedule.Models
{
    public class Room : IIdentifyingEntity<ulong>, IFullNamedEntity
    {
        public ushort Number { get; set; }
        public ulong Id { get; set; }
        public string FullName { get; set; }

        public Room(ushort number) : base()
        {
            Number = number;
        }
        public Room(ushort number, Building build) : this(number)
        {
            build.AddRoom(this);
        }

        public override string ToString()
        {
            return $"Room #{Number}";
        }
    }
}

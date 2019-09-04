using System;
using System.Collections.Generic;

namespace Schedule.Models
{
    public class Building : IIdentifyingEntity<Guid>
    {
        public readonly ushort MAX_COUNT_OF_ROOMS_ON_STOREY = 600;
        public byte CountOfStoreys { get; set; } = 4;
        public byte Number { get; set; }
        public IList<Room> Rooms { get; set; } = new List<Room>();
        public Guid Id { get; set; }

        public Building(byte number)
        {
            Number = number;
        }
        public Building(byte number, IEnumerable<Room> rooms) : this(number)
        {
            Rooms = rooms as List<Room>;
        }

        public void AddRoom(Room room)
        {
            if (Rooms.Contains(room))
                return;
            else
                Rooms.Add(room);
        }
        public override bool Equals(object obj)
        {
            return obj != null && (obj is Building) && Number == (obj as Building).Number;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Number);
        }
    }
}

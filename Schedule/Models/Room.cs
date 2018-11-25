using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schedule.Models
{
    public class Room : Base<Room>
    {        
        private ushort number;
        public readonly Guid BuildId;

        public Build Build
        {
            get => Build.Items[BuildId];
        }
        public ushort Number
        {
            get => number;
            set
            {
                if (value < Build.MAX_COUNT_OF_ROOMS_ON_STOREY)
                    number = value;
                else
                    throw new ArgumentException("Wrong number of room");
            }
        }

        public Room(Build build) : base()
        {
            BuildId = build.Id;
            Number = (byte)Items.Count;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Room)) return false;
            Room compRoom = obj as Room;
            return compRoom.BuildId == BuildId && compRoom.Number == Number;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(this.number, this.BuildId, Id);
        }
    }
}

using System;

namespace Schedule.Models
{
    public class Build : Base<Build>
    {
        public readonly ushort MAX_COUNT_OF_ROOMS_ON_STOREY = 600;
        public byte CountOfStoreys { get; set; } = 4;
        public byte Number { get; set; } = (byte)Items.Count;

        public Build() : base() { }

        public override bool Equals(object obj)
        {
            return obj != null && (obj is Build) && Number == (obj as Build).Number;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Number);
        }
    }
}

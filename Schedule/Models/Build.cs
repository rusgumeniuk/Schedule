using System;

namespace Schedule.Models
{
    public class Build : Base<Build>
    {
        public readonly ushort MAX_COUNT_OF_ROOMS_ON_STOREY = 600;
        public readonly byte CountOfStoreys;
        public readonly byte Number;

        public Build() : base()
        {
            this.CountOfStoreys = 4;
            this.Number = (byte)Items.Count;
        }

        public override bool Equals(object obj)
        {
            return obj != null && (obj is Build) && this.Number == (obj as Build).Number;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Id, this.Number);
        }
    }
}

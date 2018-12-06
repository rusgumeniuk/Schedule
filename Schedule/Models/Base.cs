using System;

namespace Schedule.Models
{
    public class Base
    {
        public Guid Id { get; set; }

        public Base()
        {
            Id = Guid.NewGuid();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj) && (obj.GetType().Equals(this.GetType())) && (obj as Base).Id.Equals(this.Id);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, DateTime.Now.Millisecond);
        }
    }
}

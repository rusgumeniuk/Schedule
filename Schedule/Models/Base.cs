using System;
using System.Collections.Generic;

namespace Schedule.Models
{
    public class Base<T> where T : Base<T>
    {
        public static Dictionary<Guid, T> Items = new Dictionary<Guid, T>();

        public Guid Id { get; set; }

        public Base()
        {
            Id = Guid.NewGuid();
            Items.Add(Id, (T)this);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schedule.Models
{
    public class Base<T> where T : Base<T>
    {
        public static Dictionary<Guid, T> Items = new Dictionary<Guid, T>();

        public Guid Id { get; set; }        

        public Base()
        {
            this.Id = Guid.NewGuid();            
            Items.Add(this.Id, (T)this);
        }
    }
}

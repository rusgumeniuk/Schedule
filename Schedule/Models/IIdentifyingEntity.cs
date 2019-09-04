using System;

namespace Schedule.Models
{
    interface IIdentifyingEntity<TKey> where TKey : IEquatable<TKey>
    {
        TKey Id { get; set; }
    }
}

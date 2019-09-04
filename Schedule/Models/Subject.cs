using System;

namespace Schedule.Models
{
    public class Subject : IIdentifyingEntity<long>, INamedEntity, IFullNamedEntity, IUriEntity, IRateableEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public Uri Url { get; set; }
        public double Rate { get; set; }
    }
}

using System;

namespace Schedule.Models
{
    public class Entity<T> : Base<T> where T : Entity<T>
    {
        private string title;
        public string Title
        {
            get => this.title;
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                {
                    this.title = value;
                }
                else
                {
                    throw new ArgumentException($"Wrong title:{value}");
                }
            }
        }

        public Entity() : base()
        {
            Title = $"{GetType().Name}{DateTime.Now.Millisecond}";
        }
        public Entity(string title) : this()
        {
            Title = title;
        }
    }
}

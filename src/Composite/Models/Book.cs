using System;

namespace Composite.Models
{
    public class Book : IComponent
    {
        public string Title { get; }
        public string Type => "Book";

        public Book(string title)
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));
        }

        public int Count() => 1;

        public void Add(IComponent component)
        {
            throw new NotSupportedException("Books cannot contain other IComponents.");
        }

        public string Display()
        {
            return $"{Title} <small class=\"text-muted\">({Type})</small>";
        }

        public void Remove(IComponent component)
        {
            throw new NotSupportedException("Books cannot contain other IComponents.");
        }
    }
}

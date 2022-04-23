namespace Composite.Models
{
    public interface IComponent
    {
        string Type { get; }

        void Add(IComponent component);
        int Count();
        string Display();
        void Remove(IComponent component);
    }
}
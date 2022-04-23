using System;

namespace DecoratorPlain
{
    public class DecoratorA : IComponent
    {
        private readonly IComponent component;

        public DecoratorA(IComponent component)
        {
            this.component = component ?? throw new ArgumentNullException(nameof(component));
        }

        public string Operation()
        {
            string result = component.Operation();
            return $"<DecoratorA>{result}</DecoratorA>";
        }
    }
}

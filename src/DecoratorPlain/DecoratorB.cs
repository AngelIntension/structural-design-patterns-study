namespace DecoratorPlain
{
    public class DecoratorB : IComponent
    {
        private IComponent component;

        public DecoratorB(IComponent component)
        {
            this.component = component;
        }

        public string Operation()
        {
            var result = component.Operation();
            return $"<DecoratorB>{result}</DecoratorB>";
        }
    }
}

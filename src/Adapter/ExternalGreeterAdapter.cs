using System;

namespace Adapter
{
    public class ExternalGreeterAdapter : IGreeter
    {
        private ExternalGreeter adaptee;

        public ExternalGreeterAdapter(ExternalGreeter adaptee)
        {
            this.adaptee = adaptee ?? throw new ArgumentNullException(nameof(adaptee));
        }

        public string Greeting()
        {
            return adaptee.GreetByName("System");
        }
    }
}

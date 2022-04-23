using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace DecoratorPlain
{
    public class Client
    {
        private IComponent component;

        public Client(IComponent component)
        {
            this.component = component;
        }

        public Task ExecuteAsync(HttpContext context)
        {
            var result = component.Operation();
            return context.Response.WriteAsync($"Operation: {result}");
        }
    }
}

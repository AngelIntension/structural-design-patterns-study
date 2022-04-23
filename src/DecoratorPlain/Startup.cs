using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DecoratorPlain
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<Client>();
            services.AddSingleton<IComponent, ComponentA>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, Client client)
        {
            app.Run(async context => await client.ExecuteAsync(context));
        }
    }
}

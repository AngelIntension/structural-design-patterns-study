using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Adapter
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ExternalGreeter>();
            services.AddSingleton<IGreeter, ExternalGreeterAdapter>();
        }
        
        public void Configure(IApplicationBuilder app, IGreeter greeter)
        {
            app.Run(async context =>
            {
                var greeting = greeter.Greeting();
                await context.Response.WriteAsync(greeting);
            });
        }
    }
}

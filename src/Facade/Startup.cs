using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using OpaqueFacadeSubSystem;
using OpaqueFacadeSubSystem.Abstractions;

namespace Facade
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting();
            services.AddOpaqueFacadeSubSystem();
        }
        
        public void Configure(IApplicationBuilder app, IOpaqueFacade opaqueFacade)
        {
            app.UseRouter(router =>
            {
                router.MapGet("/opaque/a", async context =>
                {
                    var result = opaqueFacade.ExecuteOperationA();
                    await context.Response.WriteAsync(result);
                });
                router.MapGet("/opaque/b", async context =>
                {
                    var result = opaqueFacade.ExecuteOperationB();
                    await context.Response.WriteAsync(result);
                });
            });
        }
    }
}

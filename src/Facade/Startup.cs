using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using OpaqueFacadeSubSystem;
using OpaqueFacadeSubSystem.Abstractions;
using TransparentFacadeSubSystem;
using TransparentFacadeSubSystem.Abstractions;

namespace Facade
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting();
            services.AddOpaqueFacadeSubSystem();
            services.AddTransparentFacadeSubSystem();
            services.AddSingleton<IComponentB, UpdatedComponentB>();
        }
        
        public void Configure(IApplicationBuilder app, IOpaqueFacade opaqueFacade, ITransparentFacade transparentFacade)
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
                router.MapGet("/transparent/a", async context =>
                {
                    var result = transparentFacade.ExecuteOperationA();
                    await context.Response.WriteAsync(result);
                });
                router.MapGet("/transparent/b", async context =>
                {
                    var result = transparentFacade.ExecuteOperationB();
                    await context.Response.WriteAsync(result);
                });
            });
        }
    }
}

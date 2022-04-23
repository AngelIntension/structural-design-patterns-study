using Composite.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Composite
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ICorporationFactory, DefaultCorporationFactory>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ICorporationFactory corporationFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async context =>
            {
                var compositeDataStructure = corporationFactory.Create();
                var output = compositeDataStructure.Display();
                context.Response.Headers.Add("Content-Type", "text/html; charset=utf-8");
                await context.Response.WriteAsync("[removed for brevity]");
                await context.Response.WriteAsync(output);
                await context.Response.WriteAsync("[removed for brevity]");
            });
        }
    }
}

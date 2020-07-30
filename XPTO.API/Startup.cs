using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using XPTO.Core.Bus;
using XPTO.Core.DomainNotification;
using XPTO.Product.Application;
using XPTO.Product.Application.Command;
using XPTO.Product.Application.Command.Handler;
using XPTO.Product.Data;
using XPTO.Product.Domain.Queries;
using XPTO.Product.Domain.Repository;

namespace XPTO.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddTransient<IProductQueries, ProductQueries>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IDomainNotification, DomainNotification> ();
            services.AddTransient<IMediatrHandler, MediatrHandler>();
            services.AddScoped<IRequestHandler<RegisterProductCommand, bool>, RegisterProductHandler>();
            services.AddMediatR(typeof(Startup));

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

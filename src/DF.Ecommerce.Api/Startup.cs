using DF.Ecommerce.Api.Assemblies;
using DF.Ecommerce.Api.Filters;
using DF.Ecommerce.Api.Logging;
using DF.Ecommerce.Infrastructure.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DF.Ecommerce.Api
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
            services.AddRouting(options => options.LowercaseUrls = true);

            services.AddCors();

            services.AddControllers();

            services.AddMvc(options =>
            {
                options.Filters.Add(new DefaultExceptionFilterAttribute());
            });

            services.AddAutoMapper(AssemblyReflection.GetCurrentAssemblies());

            services.AddLoggingSerilog();

            services.AddHealthChecks();

            services.AddRazorPages();

            services.AddDbContext<CarrinhoContext>(options => options.UseSqlServer(Configuration.GetConnectionString("defaultConnection")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseStaticFiles();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/health");
            });
        }
    }
}

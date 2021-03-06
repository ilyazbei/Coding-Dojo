using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WeddingPlanner.Models;
using MySQL.Data.EntityFrameworkCore.Extensions;
using Microsoft.Extensions.Configuration; // for secure connection
using Microsoft.AspNetCore.Hosting; // for secure connection

namespace WeddingPlanner
{
    public class Startup
    {
        // for secure connection
        public IConfiguration Configuration { get; private set; }
        // for secure connection
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddDbContext<WeddingPlannerContext>(options => options.UseMySQL(Configuration["DBInfo:ConnectionString"]));
            // Add framework services.
            services.AddMvc();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory, IHostingEnvironment env)
        {
            // if( env.IsDevelopment() )
            // {
                loggerFactory.AddConsole();
                app.UseDeveloperExceptionPage();
            // }
            app.UseStaticFiles();
            app.UseSession();
            app.UseMvc();
        }
    }
}


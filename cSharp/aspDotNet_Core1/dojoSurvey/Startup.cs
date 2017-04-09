using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;
 
namespace dojoSurvey
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Add Mvc as a service making it available across our entire app
            services.AddMvc();
        }
         
        public void Configure(IApplicationBuilder app, ILoggerFactory LoggerFactory)
        {
            LoggerFactory.AddConsole();
            app.UseStaticFiles();
            app.UseDeveloperExceptionPage();
            // Use the Mvc to handle Http requests and responses
            app.UseMvc();
        }
    }
}
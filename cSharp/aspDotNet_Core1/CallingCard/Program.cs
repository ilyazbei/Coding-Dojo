using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace CallingCard
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseKestrel()
                .UseStartup<Startup>()
                .Build();
            // Here the WebHost starts up the web app
            host.Run();
        }
    }
}

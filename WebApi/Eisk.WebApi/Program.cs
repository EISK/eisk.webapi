using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Eisk.WebApi
{
    //Comment from local, changed in experiment branch
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}

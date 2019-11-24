using System.Net;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace API.Web
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    //webBuilder.UseKestrel(serverOptions => {
                    //    serverOptions.Limits.MaxConcurrentConnections = 500;
                    //    serverOptions.Limits.MaxConcurrentUpgradedConnections = 250;
                    //})
                    webBuilder.UseStartup<Startup>();
                });
    }
}

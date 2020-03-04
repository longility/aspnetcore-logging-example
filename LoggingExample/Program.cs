using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Formatting.Elasticsearch;

namespace LoggingExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseSerilog((ctx, cfg) =>
                    {
                        cfg.MinimumLevel.Information()
                        .Enrich.FromLogContext();
                        cfg.WriteTo.Console(new ElasticsearchJsonFormatter());
                    });
                });
    }
}

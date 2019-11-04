using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ConsoleTest
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = Host.CreateDefaultBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<MyServiceA>();
                    services.AddHostedService<MyServiceB>();
                });

            await builder.RunConsoleAsync(options =>
            {
                options.SuppressStatusMessages = false;
            });
        }
    }
}

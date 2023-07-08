using CronEval.Lib;
using CronEval.Lib.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


public class Program
{
    public static void Main(string[] args)
    {
        HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
        var serviceProvider = new ServiceCollection()
            .AddScoped<ICronParser, CronParser>()
            .BuildServiceProvider();

        Console.WriteLine(new ConsoleApp.CronParsingService(cronParser: serviceProvider.GetService<ICronParser>()).Parse(args[0]));
    }
}
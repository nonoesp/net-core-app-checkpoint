using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Binder;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.Collections.Generic;

namespace MyFirstAppv2
{
    class Program
    {
        static public string DefaultConnectionString { get; } = @"Server=(localdb)\\ms";
        static IReadOnlyDictionary<string, string> DefaultConfigurationStrings { get; } =
            new Dictionary<string, string>()
            {
                ["Profile:Username"] = Environment.UserName,
                ["AppConfiguration:ConnectionString"] = DefaultConnectionString,
                ["AppConfiguration:MainWindow:Width"] = "50",
                ["AppConfiguration:MainWindow:Height"] = "20",
            };
        static public IConfiguration Configuration { get; set; }
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddInMemoryCollection(DefaultConfigurationStrings);
            //configurationBuilder.AddJsonFile("appsettings.json", true, true);

            Configuration = configurationBuilder.Build();

            // Get width and height from in-memory configuration
            var width = Configuration.GetValue<int>("AppConfiguration:MainWindow:Width");
            var height = Configuration.GetValue<int>("AppConfiguration:MainWindow:Height");

            Console.SetWindowSize(width, height);

            Console.WriteLine($"Hello {Configuration.GetValue<string>("Profile:UserName", "McDefault")}");
            Console.WriteLine($"Width ({width}) and Height ({height}).");

            Console.ReadKey();

        }
    }
}

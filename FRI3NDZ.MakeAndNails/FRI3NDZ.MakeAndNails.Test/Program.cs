using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Common;
using NUnitLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace FRI3NDZ.MakeAndNails.Test
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var writter = new ExtendedTextWrapper(Console.Out);
            new AutoRun(typeof(Program).GetTypeInfo().Assembly).Execute(args, writter, Console.In);

            Console.ReadKey();

            //IServiceCollection serviceCollection = new ServiceCollection();
            //ConfigureServices(serviceCollection);
            //IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();   
        }

        //private static void ConfigureServices(IServiceCollection services)
        //{
        //    IConfigurationRoot configuration = GetConfiguration();
        //    services.AddSingleton<IConfigurationRoot>(configuration);

        //    services.AddOptions();
        //    services.AddDbContext<_TestDbContext>(options =>
        //            options.UseNpgsql(configuration.GetValue<string>("Data:MakeAndNailsDbContext:ConnectionString")));
        //}

        //private static IConfigurationRoot GetConfiguration()
        //{
        //    return new ConfigurationBuilder()
        //        .SetBasePath(Directory.GetCurrentDirectory())
        //        .AddJsonFile($"appsettings.json", optional: true)
        //        .Build();
        //}
    }
}

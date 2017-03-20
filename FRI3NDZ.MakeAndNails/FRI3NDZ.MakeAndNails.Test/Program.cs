using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FRI3NDZ.MakeAndNails.Test
{
    public class Program
    {
        public static void Main(string[] args)
        {
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

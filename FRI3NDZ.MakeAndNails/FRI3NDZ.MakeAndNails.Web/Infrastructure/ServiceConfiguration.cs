using FRI3NDZ.MakeAndNails.Core.Interfaces.Data;
using FRI3NDZ.MakeAndNails.Core.Interfaces.Services.Data;
using FRI3NDZ.MakeAndNails.Core.Services.Data;
using FRI3NDZ.MakeAndNails.Data;
using FRI3NDZ.MakeAndNails.Data.UnitOfWork;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FRI3NDZ.MakeAndNails.Web.Infrastructure
{
    /// <summary>
    /// Конфигурация зависимостей проектов.
    /// </summary>
    public static class ServiceConfiguration
    {
        /// <summary>
        /// Задать зависимости проектов.
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureServices(IServiceCollection services, IConfigurationRoot configuration)
        {
            services.AddSingleton<IConfiguration>((serviceProvider) => configuration);
            ConfigureCoreServices(services);
            ConfigureDataServices(services);
        }
        
        /// <summary>
        /// Задать зависимости проекта .Core.
        /// </summary>
        /// <param name="services">Набор сервисов.</param>
        private static void ConfigureCoreServices(IServiceCollection services)
        {
            services.AddTransient<I_TestDataService, _TestDataService>();
            services.AddTransient<IAuthenticationDataService, AuthenticationDataService>();
        }

        /// <summary>
        /// Задать зависимости проекта .Data.
        /// </summary>
        /// <param name="services">Набор сервисов.</param>
        private static void ConfigureDataServices(IServiceCollection services)
        {
            FluentMappingConfiguration.ConfigureMapping();
            services.AddTransient<IUnitOfWorkFactory, UnitOfWorkFactory>();
        }
    }
}

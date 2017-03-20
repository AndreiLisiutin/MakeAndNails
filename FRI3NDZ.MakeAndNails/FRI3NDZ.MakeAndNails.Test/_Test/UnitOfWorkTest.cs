using Dapper.FluentMap;
using Dapper.FluentMap.Dommel;
using FRI3NDZ.MakeAndNails.Core.Models.Domain;
using FRI3NDZ.MakeAndNails.Data;
using FRI3NDZ.MakeAndNails.Data.Mapping;
using FRI3NDZ.MakeAndNails.Data.UnitOfWork;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FRI3NDZ.MakeAndNails.Test._Test
{
    /// <summary>
    /// Временно.
    /// </summary>
    [TestFixture]
    public class UnitOfWorkTest
    {
        [TestCase()]
        public void Test()
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            FluentMappingConfiguration.ConfigureMapping();

            IConfigurationRoot configuration = GetConfiguration();
            using (UnitOfWork unitOfWork = new UnitOfWork(configuration))
            {
                unitOfWork.BeginTransaction();
                List<_TestEntity> list = unitOfWork._TestEntityRepository.GetAll();
                _TestEntity first = list.First();
                first.Name = "Updated name 3";
                unitOfWork._TestEntityRepository.Update(first);
                unitOfWork.RollbackTransaction();
            }
        }
        private static IConfigurationRoot GetConfiguration()
        {
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.json", optional: true)
                .Build();
        }
    }
}

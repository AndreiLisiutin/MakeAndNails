using Dapper.FluentMap;
using Dapper.FluentMap.Dommel;
using FRI3NDZ.MakeAndNails.Core.Infrastructure;
using FRI3NDZ.MakeAndNails.Core.Models.Domain;
using FRI3NDZ.MakeAndNails.Core.Models.Filters;
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
			try
			{
				IServiceCollection serviceCollection = new ServiceCollection();
				FluentMappingConfiguration.ConfigureMapping();

				IConfigurationRoot configuration = GetConfiguration();
				using (UnitOfWork unitOfWork = new UnitOfWork(configuration))
				{
					unitOfWork.BeginTransaction();
					UserBase user = new UserBase()
					{
						Login = "login",
						Name = "--",
						Surname = "login",
						CreatedOn = DateTime.Now,
						PasswordHash = SecurePasswordHasher.Hash("password")
					};
					user.Id = unitOfWork.UserRepository.Insert(user);

					var list = unitOfWork.UserRepository.Query(new UserFilter() { Login = "login" });

					unitOfWork.RollbackTransaction();

					//            unitOfWork.BeginTransaction();
					//            List<_TestEntityBase> list = unitOfWork._TestEntityRepository.GetAllBase();
					//_TestEntityBase first = list.First();
					//            first.Name = "Updated name 3";
					//            unitOfWork._TestEntityRepository.Update(first);
					//            unitOfWork.RollbackTransaction();
				}
			}
			catch (Exception ex)
			{
				throw;
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

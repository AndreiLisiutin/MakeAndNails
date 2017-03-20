using FRI3NDZ.MakeAndNails.Core.Interfaces.Data;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FRI3NDZ.MakeAndNails.Data.UnitOfWork
{
    /// <summary>
    /// Фабрика единиц работы.
    /// </summary>
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        /// <summary>
        /// Создать новую единицу работы с заданной конфигурацией.
        /// </summary>
        /// <param name="configuration">Конфигурация для единицы работы.</param>
        /// <returns>Экземпляр единицы работы.</returns>
        public IUnitOfWork Create(IConfiguration configuration)
        {
            return new UnitOfWork(configuration);
        }
    }
}

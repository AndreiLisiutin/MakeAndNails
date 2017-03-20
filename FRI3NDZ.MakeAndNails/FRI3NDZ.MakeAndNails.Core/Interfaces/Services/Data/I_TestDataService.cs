using FRI3NDZ.MakeAndNails.Core.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FRI3NDZ.MakeAndNails.Core.Interfaces.Services.Data
{
    /// <summary>
    /// Тестовый сервис для работы с данными.
    /// </summary>
    public interface I_TestDataService
    {
        /// <summary>
        /// Получить список тестовых сущностей.
        /// </summary>
        /// <returns></returns>
        List<_TestEntity> GetTestEntities();
    }
}

using FRI3NDZ.MakeAndNails.Core.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using FRI3NDZ.MakeAndNails.Core.Interfaces.Data;
using FRI3NDZ.MakeAndNails.Core.Interfaces.Services.Data;

namespace FRI3NDZ.MakeAndNails.Core.Services.Data
{
    /// <summary>
    /// Тестовый сервис для работы с данными.
    /// </summary>
    public class _TestDataService : I_TestDataService
    {
        private IConfiguration _configuration;
        private IUnitOfWorkFactory _unitOfWorkFactory;

        /// <summary>
        /// Конструктор тестового сервиса для работы с данными.
        /// </summary>
        /// <param name="configuration">Конфигурация запускаемого проекта.</param>
        /// <param name="unitOfWorkFactory">Фабрика единиц работы.</param>
        public _TestDataService(IConfiguration configuration, IUnitOfWorkFactory unitOfWorkFactory)
        {
            this._configuration = configuration;
            this._unitOfWorkFactory = unitOfWorkFactory;
        }

        /// <summary>
        /// Получить список тестовых сущностей.
        /// </summary>
        /// <returns></returns>
        public List<_TestEntity> GetTestEntities()
        {
            using (var unitOfWork = _unitOfWorkFactory.Create(this._configuration))
            {
                return unitOfWork._TestEntityRepository.GetAll();
            }
        }

    }
}

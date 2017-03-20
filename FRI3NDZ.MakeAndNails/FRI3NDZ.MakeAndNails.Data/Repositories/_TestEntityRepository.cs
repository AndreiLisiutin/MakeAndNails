using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data;
using Npgsql;
using Dapper;
using Dommel;
using FRI3NDZ.MakeAndNails.Core.Models.Domain;
using FRI3NDZ.MakeAndNails.Core.Interfaces.Data;
using FRI3NDZ.MakeAndNails.Data.UnitOfWork;

namespace FRI3NDZ.MakeAndNails.Data.Repositories
{
    /// <summary>
    /// Репозиторий тестовых сущностей.
    /// </summary>
    internal class _TestEntityRepository : I_TestEntityRepository
    {
        private DataContext _dataContext;

        /// <summary>
        /// Конструктор репозитория тестовых сущностей.
        /// </summary>
        /// <param name="dataContext">Контекст данных (подключение к базе и транзакция).</param>
        public _TestEntityRepository(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }

        /// <summary>
        /// Вставить новый экземпляр сущности.
        /// </summary>
        /// <param name="item">Модель нового экземпляра сущности.</param>
        /// <returns>Идентификатор нового экземпляра сущности.</returns>
        public int Insert(_TestEntityBase item)
        {
            return (int)_dataContext.Connection.Insert(item, this._dataContext.Transaction);
        }

        /// <summary>
        /// Обновить существующий экземпляр сущности.
        /// </summary>
        /// <param name="item">Модель экземпляра сущности.</param>
        public void Update(_TestEntityBase item)
        {
            _dataContext.Connection.Update(item, this._dataContext.Transaction);
        }

        /// <summary>
        /// Удалить существующий экземпляр сущности.
        /// </summary>
        /// <param name="item">Модель экземпляра сущности.</param>
        public void Delete(_TestEntityBase item)
        {
            _dataContext.Connection.Delete(item, this._dataContext.Transaction);
        }

        /// <summary>
        /// Получить список всех экземпляров сущности.
        /// </summary>
        /// <returns>Список всех экземпляров сущности.</returns>
        public List<_TestEntity> GetAll()
        {
            return _dataContext.Connection.GetAll<_TestEntity>().ToList();
        }

        /// <summary>
        /// Получить экземпляр сущности по его идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор экземпляра сущности.</param>
        /// <returns>Найденный экземпляр сущности.</returns>
        public _TestEntity GetByID(int id)
        {
            return _dataContext.Connection.Get<_TestEntity>(id);
        }
    }

}

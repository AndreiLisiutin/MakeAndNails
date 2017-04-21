using FRI3NDZ.MakeAndNails.Core.Interfaces.Data;
using FRI3NDZ.MakeAndNails.Core.Interfaces.Data.Repositories;
using FRI3NDZ.MakeAndNails.Data.Repositories;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace FRI3NDZ.MakeAndNails.Data.UnitOfWork
{
    /// <summary>
    /// Единица работы (Паттерн Unit of Work).
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// Имя узла конфигурации, хранящее значение строки подключения к БД.
        /// </summary>
        private const string _CONNECTION_STRING_NAME = "Data:MakeAndNailsDbContext:ConnectionString";
        private Lazy<DataContext> _dataContext;

		/// <summary>
		/// Репозиторий тестовых сущностей.
		/// </summary>
		public I_TestEntityRepository _TestEntityRepository => new _TestEntityRepository(this._dataContext.Value);

		/// <summary>
		/// Репозиторий пользователей.
		/// </summary>
		public IUserRepository UserRepository => new UserRepository(this._dataContext.Value);
		
		/// <summary>
		/// Конструктор единицы работы.
		/// </summary>
		/// <param name="configuration">Конфигурация запускаемого проекта. 
		/// Должен быть заполнен узел для строки подключения к базе данных (<see cref="_CONNECTION_STRING_NAME"/>).</param>
		public UnitOfWork(IConfiguration configuration)
        {
            this._dataContext = new Lazy<DataContext>(() => this._CreateDataContext(configuration), true);
        }

        /// <summary>
        /// Установка соединения с базой данных.
        /// </summary>
        /// <param name="configuration">Конфигурация запускаемого проекта.</param>
        /// <returns>Контекст данных.</returns>
        private DataContext _CreateDataContext(IConfiguration configuration)
        {
            string connectionString = configuration.GetValue<string>(_CONNECTION_STRING_NAME);
            IDbConnection connection = new NpgsqlConnection(connectionString);
            connection.Open();
            return new DataContext(connection, null);
        }

        /// <summary>
        /// Открыть транзакцию.
        /// </summary>
        public void BeginTransaction()
        {
            this._dataContext.Value.Transaction = this._dataContext.Value.Connection.BeginTransaction();
        }

        /// <summary>
        /// Подтвердить транзакцию, если она открыта.
        /// </summary>
        public void CommitTransaction()
        {
            if (this._dataContext.Value.Transaction != null)
            {
                this._dataContext.Value.Transaction.Commit();
                this._dataContext.Value.Transaction.Dispose();
                this._dataContext.Value.Transaction = null;
            }
        }

        /// <summary>
        /// Откатить транзакцию, если она открыта.
        /// </summary>
        public void RollbackTransaction()
        {
            if (this._dataContext.Value.Transaction != null)
            {
                this._dataContext.Value.Transaction.Rollback();
                this._dataContext.Value.Transaction.Dispose();
                this._dataContext.Value.Transaction = null;
            }
        }

        /// <summary>
        /// Освободить неуправляемые ресурсы единицы работы такие, как подключение к базе данных и транзакция.
        /// Если транзакция не закрыта, она откатывается.
        /// </summary>
        public void Dispose()
        {
            if (this._dataContext.IsValueCreated)
            {
                this.RollbackTransaction();
                if (this._dataContext.Value.Connection != null)
                {
                    this._dataContext.Value.Connection.Dispose();
                    this._dataContext.Value.Connection = null;
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace FRI3NDZ.MakeAndNails.Data.UnitOfWork
{
    /// <summary>
    /// Контекст данных для работы с БД.
    /// </summary>
    public class DataContext
    {
        /// <summary>
        /// Конструктор контекста данных для работы с БД.
        /// </summary>
        /// <param name="connection">Подключение к БД.</param>
        /// <param name="transaction">Транзакция, если есть</param>
        public DataContext(IDbConnection connection, IDbTransaction transaction = null)
        {
            this.Connection = connection;
            this.Transaction = transaction;
        }

        /// <summary>
        /// Подключение к базе данных.
        /// </summary>
        public IDbConnection Connection { get; set; }

        /// <summary>
        /// Транзакция, открытая в базе данных, или NULL.
        /// </summary>
        public IDbTransaction Transaction { get; set; }
    }
}

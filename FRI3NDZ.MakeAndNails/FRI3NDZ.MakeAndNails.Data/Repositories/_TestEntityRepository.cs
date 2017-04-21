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
using FRI3NDZ.MakeAndNails.Data.UnitOfWork;
using FRI3NDZ.MakeAndNails.Core.Interfaces.Data.Repositories;

namespace FRI3NDZ.MakeAndNails.Data.Repositories
{
    /// <summary>
    /// Репозиторий тестовых сущностей.
    /// </summary>
    internal class _TestEntityRepository : RepositoryBase<_TestEntityBase>, I_TestEntityRepository
    {
        /// <summary>
        /// Конструктор репозитория тестовых сущностей.
        /// </summary>
        /// <param name="dataContext">Контекст данных (подключение к базе и транзакция).</param>
        public _TestEntityRepository(DataContext dataContext)
			:base(dataContext)
        {
        }
    }

}

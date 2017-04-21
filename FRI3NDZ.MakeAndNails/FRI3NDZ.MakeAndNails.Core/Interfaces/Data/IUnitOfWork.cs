using FRI3NDZ.MakeAndNails.Core.Interfaces.Data.Repositories;
using System;

namespace FRI3NDZ.MakeAndNails.Core.Interfaces.Data
{
    /// <summary>
    /// Единица работы (Паттерн Unit of Work).
    /// </summary>
    public interface IUnitOfWork : IDisposable
	{
		/// <summary>
		/// Репозиторий тестовых сущностей.
		/// </summary>
		I_TestEntityRepository _TestEntityRepository { get; }

		/// <summary>
		/// Репозиторий пользователей.
		/// </summary>
		IUserRepository UserRepository { get; }

		/// <summary>
		/// Открыть транзакцию.
		/// </summary>
		void BeginTransaction();

        /// <summary>
        /// Подтвердить транзакцию, если она открыта.
        /// </summary>
        void CommitTransaction();

        /// <summary>
        /// Откатить транзакцию, если она открыта.
        /// </summary>
        void RollbackTransaction();
    }
}

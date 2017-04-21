using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data;
using Npgsql;
using Dapper;
using FRI3NDZ.MakeAndNails.Core.Models.Domain;
using FRI3NDZ.MakeAndNails.Data.UnitOfWork;
using FRI3NDZ.MakeAndNails.Core.Interfaces.Data.Repositories;
using FRI3NDZ.MakeAndNails.Core.Models.Filters;

namespace FRI3NDZ.MakeAndNails.Data.Repositories
{
	/// <summary>
	/// Репозиторий пользователей.
	/// </summary>
	internal class UserRepository : RepositoryBase<UserBase>, IUserRepository
	{
		/// <summary>
		/// Конструктор репозитория пользователей.
		/// </summary>
		/// <param name="dataContext">Контекст данных (подключение к базе и транзакция).</param>
		public UserRepository(DataContext dataContext)
			: base(dataContext)
		{
		}

		/// <summary>
		/// Получить пользователя по его идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор пользователя.</param>
		/// <returns>Найденный пользователь.</returns>
		public User GetById(int id)
		{
			return this.Query(new UserFilter()
			{
				Id = id,
				PageSize = 1,
				PageNumber = 0
			})
				.FirstOrDefault();
		}

		/// <summary>
		/// Получить список пользователей по фильтру.
		/// </summary>
		/// <param name="filter">Фильтр.</param>
		/// <returns>Список отфильтрованных пользователей.</returns>
		public List<User> Query(UserFilter filter)
		{
			DynamicParameters @params = new DynamicParameters();
			@params.Add("_id", filter.Id, DbType.Int32);
			@params.Add("_login", filter.Login, DbType.String);
			@params.Add("_page_size", filter.PageSize, DbType.Int32);
			@params.Add("_page_number", filter.PageNumber, DbType.Int32);

			return this._dataContext.Connection.Query<User>("User$Query", @params, this._dataContext.Transaction, commandType: CommandType.StoredProcedure)
				.ToList();
		}

		/// <summary>
		/// Сохранить пользователя.
		/// </summary>
		/// <param name="item">Модель пользователя.</param>
		/// <returns>Обновленная модель пользователя с идентификатором.</returns>
		public UserBase Save(UserBase item)
		{
			DynamicParameters @params = new DynamicParameters();
			@params.Add("_id", item.Id, DbType.Int32);
			@params.Add("_name", item.Name, DbType.String);
			@params.Add("_surname", item.Surname, DbType.String);
			@params.Add("_patronymic", item.Patronymic, DbType.String);
			@params.Add("_login", item.Login, DbType.String);
			@params.Add("_email", item.Email, DbType.String);
			@params.Add("_password_hash", item.PasswordHash, DbType.String);
			@params.Add("_created_on", item.CreatedOn, DbType.DateTime);
			@params.Add("_phone", item.Phone, DbType.String);

			item.Id = this._dataContext.Connection.ExecuteScalar<int>("User$Save", @params, this._dataContext.Transaction, commandType: CommandType.StoredProcedure);
			return item;
		}

		/// <summary>
		/// Удалить пользователя.
		/// </summary>
		/// <param name="id">Идентификатор пользователя.</param>
		/// <returns>Идентификатор пользователя.</returns>
		public int Delete(int id)
		{
			DynamicParameters @params = new DynamicParameters();
			@params.Add("_id", id, DbType.Int32);

			var result = this._dataContext.Connection.ExecuteScalar<int>("User$Delete", @params, this._dataContext.Transaction, commandType: CommandType.StoredProcedure);
			return result;
		}
	}

}

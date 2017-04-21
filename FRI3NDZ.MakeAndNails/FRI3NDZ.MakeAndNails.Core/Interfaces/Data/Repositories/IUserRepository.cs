using FRI3NDZ.MakeAndNails.Core.Models.Domain;
using FRI3NDZ.MakeAndNails.Core.Models.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FRI3NDZ.MakeAndNails.Core.Interfaces.Data.Repositories
{
    /// <summary>
    /// Репозиторий пользователей.
    /// </summary>
    public interface IUserRepository: IRepositoryBase<UserBase>
	{
		/// <summary>
		/// Получить список пользователей по фильтру.
		/// </summary>
		/// <param name="filter">Фильтр.</param>
		/// <returns>Список отфильтрованных пользователей.</returns>
		List<User> Query(UserFilter filter);

		/// <summary>
		/// Сохранить пользователя.
		/// </summary>
		/// <param name="item">Модель пользователя.</param>
		/// <returns>Обновленная модель пользователя с идентификатором.</returns>
		UserBase Save(UserBase item);

		/// <summary>
		/// Получить пользователя по его идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор пользователя.</param>
		/// <returns>Найденный пользователь.</returns>
		User GetById(int id);

		/// <summary>
		/// Удалить пользователя.
		/// </summary>
		/// <param name="id">Идентификатор пользователя.</param>
		/// <returns>Идентификатор пользователя.</returns>
		int Delete(int id);
    }
}

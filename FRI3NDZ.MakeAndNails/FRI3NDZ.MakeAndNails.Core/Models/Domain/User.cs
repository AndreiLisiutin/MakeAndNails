using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FRI3NDZ.MakeAndNails.Core.Models.Domain
{
	/// <summary>
	/// Расширенная модель пользователя.
	/// </summary>
	public class User : UserBase
	{
	}

	/// <summary>
	/// Доменная модель пользователя.
	/// </summary>
	public class UserBase
    {
		/// <summary>
		/// Идентификатор пользователя.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Имя пользователя.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Фамилия пользователя.
		/// </summary>
		public string Surname { get; set; }

		/// <summary>
		/// Отчество пользователя.
		/// </summary>
		public string Patronymic { get; set; }

		/// <summary>
		/// Логин.
		/// </summary>
		public string Login { get; set; }

		/// <summary>
		/// Хэш пароля.
		/// </summary>
		public string PasswordHash { get; set; }

		/// <summary>
		/// Дата регистрации пользователя.
		/// </summary>
		public DateTime CreatedOn { get; set; }

		/// <summary>
		/// Телефон.
		/// </summary>
		public string Phone { get; set; }

		/// <summary>
		/// Адрес электронной почты.
		/// </summary>
		public string Email { get; set; }
	}
}

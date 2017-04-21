using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FRI3NDZ.MakeAndNails.Core.Models.Filters
{
	/// <summary>
	/// Фильтр пользователей.
	/// </summary>
    public class UserFilter
    {
		/// <summary>
		/// Логин.
		/// </summary>
		public string Login { get; set; }

		/// <summary>
		/// Идентификатор пользователя.
		/// </summary>
		public int? Id { get; set; }

		/// <summary>
		/// Размер страницы.
		/// </summary>
		public int? PageSize { get; set; }

		/// <summary>
		/// Номер страницы.
		/// </summary>
		public int? PageNumber { get; set; }

	}
}

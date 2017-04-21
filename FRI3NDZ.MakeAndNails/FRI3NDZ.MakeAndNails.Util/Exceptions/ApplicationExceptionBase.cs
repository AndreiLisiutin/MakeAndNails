using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FRI3NDZ.MakeAndNails.Util.Exceptions
{
	/// <summary>
	/// Кастомный класс для исключений.
	/// </summary>
	public class ApplicationExceptionBase : Exception
	{
		/// <summary>
		/// Конструктор кастомного исключения.
		/// </summary>
		public ApplicationExceptionBase() : base()
		{ }

		/// <summary>
		/// Конструктор кастомного исключения.
		/// </summary>
		/// <param name="message">Сообщение об ошибке.</param>
		public ApplicationExceptionBase(string message) : base(message)
		{ }

		/// <summary>
		/// Конструктор кастомного исключения.
		/// </summary>
		/// <param name="message">Сообщение об ошибке.</param>
		/// <param name="innerException">Внутреннее исключение.</param>
		public ApplicationExceptionBase(string message, Exception innerException) : base(message, innerException)
		{ }
	}
}

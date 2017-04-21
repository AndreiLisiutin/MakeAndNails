using FRI3NDZ.MakeAndNails.Util.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FRI3NDZ.MakeAndNails.Util
{
	/// <summary>
	/// Сервис для проверки аргументов.
	/// </summary>
	public static class Argument
	{
		/// <summary>
		/// Проверить объект на пустоту.
		/// </summary>
		/// <typeparam name="T">Тип объекта.</typeparam>
		/// <param name="object">Объект.</param>
		/// <param name="exception">Сообщение об ошибке.</param>
		public static void NotNull<T>(T @object, string exception)
		{
			if (@object == null || @object.Equals(default(T)))
			{
				throw new ApplicationExceptionBase(exception);
			}
		}

		/// <summary>
		/// Проверить строку на NULL или пустоту.
		/// </summary>
		/// <param name="object">Строка.</param>
		/// <param name="exception">Сообщение об ошибке.</param>
		public static void NotNullOrWhiteSpace(string @object, string exception)
		{
			if (string.IsNullOrWhiteSpace(@object))
			{
				throw new ApplicationExceptionBase(exception);
			}
		}

		/// <summary>
		/// Проверить число на положительное значение.
		/// </summary>
		/// <param name="object">Число.</param>
		/// <param name="exception">Сообщение об ошибке.</param>
		public static void Positive(decimal? @object, string exception)
		{
			if (@object == null || @object <= 0)
			{
				throw new ApplicationExceptionBase(exception);
			}
		}
		
		/// <summary>
		/// Проверить число на положительное значение.
		/// </summary>
		/// <param name="object">Число.</param>
		/// <param name="exception">Сообщение об ошибке.</param>
		public static void Positive(double? @object, string exception)
		{
			if (@object == null || @object <= 0)
			{
				throw new ApplicationExceptionBase(exception);
			}
		}
		
		/// <summary>
		/// Проверить число на положительное значение.
		/// </summary>
		/// <param name="object">Число.</param>
		/// <param name="exception">Сообщение об ошибке.</param>
		public static void Positive(long? @object, string exception)
		{
			if (@object == null || @object <= 0)
			{
				throw new ApplicationExceptionBase(exception);
			}
		}
		
		/// <summary>
		/// Проверить произвольное условие.
		/// </summary>
		/// <param name="object">Результат проверки.</param>
		/// <param name="exception">Сообщение об ошибке.</param>
		public static void Require(bool condition, string exception)
		{
			if (!condition)
			{
				throw new ApplicationExceptionBase(exception);
			}
		}
	}
}

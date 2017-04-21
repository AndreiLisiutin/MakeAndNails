using FRI3NDZ.MakeAndNails.Util.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace FRI3NDZ.MakeAndNails.Web.Infrastructure
{
	/// <summary>
	/// Обработчик ошибок ASP.NET.
	/// </summary>
	public class ExceptionHandlingMiddleware
	{
		private readonly RequestDelegate _next;
		private static readonly object _loggerLock = new object();
		private ILogger _Logger { get; }

		/// <summary>
		/// Конструктор обработчика ошибок ASP.NET.
		/// </summary>
		/// <param name="next">Следующее действие в цепочке обработки запроса.</param>
		public ExceptionHandlingMiddleware(RequestDelegate next, ILoggerFactory loggerFactory, IServiceProvider serviceProvider)
		{
			this._next = next;
			this._Logger = loggerFactory.CreateLogger(GetType().Name);
		}

		/// <summary>
		/// Действия по обработке запроса ASP.NET.
		/// </summary>
		/// <param name="context">Контекст запроса ASP.NET.</param>
		/// <returns>Задача на обработку запроса ASP.NET.</returns>
		public async Task Invoke(HttpContext context)
		{
			try
			{
				await _next(context);
			}
			catch (Exception ex)
			{
				await HandleExceptionAsync(context, ex);
			}
		}

		/// <summary>
		/// Обработка исключения.
		/// </summary>
		/// <param name="context">Контекст запроса ASP.NET.</param>
		/// <param name="exception">Исключение.</param>
		/// <returns>Задача на обработку запроса ASP.NET.</returns>
		private Task HandleExceptionAsync(HttpContext context, Exception exception)
		{
			Guid errorId = Guid.NewGuid();
			
			var responseCode = HttpStatusCode.InternalServerError;
			var errorText = exception.Message;
			LogLevel? logLevel = null;
			if (exception is SecurityTokenExpiredException)
			{
				responseCode = HttpStatusCode.Unauthorized;
				errorText = "Время сессии истекло. Войдите в систему заново.";
				logLevel = null;
			}
			else if (exception is ApplicationExceptionBase)
			{
				responseCode = HttpStatusCode.BadRequest;
				errorText = exception.Message;
				logLevel = LogLevel.Warning;
			}
			else
			{
				responseCode = HttpStatusCode.InternalServerError;
				errorText = $"Ошибка {errorId}: {exception.Message}";
				logLevel = LogLevel.Error;
			}

			this._WriteLog(errorId, exception, logLevel);
			
			context.Response.ContentType = "application/json";
			context.Response.StatusCode = (int)responseCode;
			return context.Response.WriteAsync(errorText);
		}

		/// <summary>
		/// Записать в лог исключение.
		/// </summary>
		/// <param name="errorId">Идентификатор исключения.</param>
		/// <param name="exception">Исключение.</param>
		/// <param name="level">Уровень исключения. Если он пустой, лог не пишется.</param>
		private void _WriteLog(Guid errorId, Exception exception, LogLevel? level = null)
		{
			if (!level.HasValue)
			{
				return;
			}

			string errorText = $"Ошибка {errorId}. {exception.ToString()}";
			lock (_loggerLock)
			{
				switch (level.Value)
				{
					case LogLevel.Critical:
						_Logger.LogCritical(errorText);
						break;
					case LogLevel.Debug:
						_Logger.LogDebug(errorText);
						break;
					case LogLevel.Error:
						_Logger.LogError(errorText);
						break;
					case LogLevel.Information:
						_Logger.LogInformation(errorText);
						break;
					case LogLevel.None:
						//ничего не делать
						break;
					case LogLevel.Trace:
						_Logger.LogTrace(errorText);
						break;
					case LogLevel.Warning:
						_Logger.LogWarning(errorText);
						break;
				}
			}
		}
	}
}

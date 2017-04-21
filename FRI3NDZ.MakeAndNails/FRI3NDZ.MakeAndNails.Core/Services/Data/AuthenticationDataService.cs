using FRI3NDZ.MakeAndNails.Core.Interfaces.Data;
using FRI3NDZ.MakeAndNails.Core.Models.Domain;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using FRI3NDZ.MakeAndNails.Core.Infrastructure;
using FRI3NDZ.MakeAndNails.Core.Models.Filters;
using FRI3NDZ.MakeAndNails.Util;
using FRI3NDZ.MakeAndNails.Core.Interfaces.Services.Data;

namespace FRI3NDZ.MakeAndNails.Core.Services.Data
{
	/// <summary>
	/// Сервис для работы с аутентификацией.
	/// </summary>
	public class AuthenticationDataService : IAuthenticationDataService
	{
		private IConfiguration _configuration;
		private IUnitOfWorkFactory _unitOfWorkFactory;

		/// <summary>
		/// Конструктор сервиса для работы с аутентификацией.
		/// </summary>
		/// <param name="configuration">Конфигурация запускаемого проекта.</param>
		/// <param name="unitOfWorkFactory">Фабрика единиц работы.</param>
		public AuthenticationDataService(IConfiguration configuration, IUnitOfWorkFactory unitOfWorkFactory)
		{
			this._configuration = configuration;
			this._unitOfWorkFactory = unitOfWorkFactory;
		}

		public UserBase CreateUser(string login, string password)
		{
			Argument.Require(!string.IsNullOrWhiteSpace(login), "Логин пользователя не задан.");
			Argument.Require(!string.IsNullOrWhiteSpace(password), "Пароль пользователя не задан.");

			UserBase user = new UserBase()
			{
				Id = 0,
				Login = login,
				Name = "--",
				Surname = login,
				CreatedOn = DateTime.Now,
				PasswordHash = this._HashPassword(password)
			};
			using (var unitOfWork = _unitOfWorkFactory.Create(this._configuration))
			{
				UserBase existingUser = unitOfWork.UserRepository.Query(new UserFilter() { Login = login })
					.FirstOrDefault();
				Argument.Require(existingUser == null, "Пользователь с выбранным логином уже существует.");

				user = unitOfWork.UserRepository.Save(user);
			}
			return user;
		}

		public UserBase VerifyUser(string login, string password)
		{
			Argument.Require(!string.IsNullOrWhiteSpace(login), "Логин пользователя не задан.");
			Argument.Require(!string.IsNullOrWhiteSpace(password), "Пароль пользователя не задан.");

			using (var unitOfWork = _unitOfWorkFactory.Create(this._configuration))
			{
				UserBase user = unitOfWork.UserRepository.Query(new UserFilter() { Login = login })
					.FirstOrDefault();
				if (user == null)
				{
					return null;
				}

				bool isUserExists = this._VerifyPassword(password, user.PasswordHash);
				return isUserExists ? user : null;
			}
		}

		private string _HashPassword(string password)
		{
			return SecurePasswordHasher.Hash(password);
		}
		private bool _VerifyPassword(string password, string hash)
		{
			return SecurePasswordHasher.Verify(password, hash);
		}
	}
}

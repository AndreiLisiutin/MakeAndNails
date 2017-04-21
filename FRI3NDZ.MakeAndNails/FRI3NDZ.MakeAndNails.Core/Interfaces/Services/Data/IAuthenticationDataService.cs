using FRI3NDZ.MakeAndNails.Core.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FRI3NDZ.MakeAndNails.Core.Interfaces.Services.Data
{
	/// <summary>
	/// Сервис аутентификации и работы с учетными записями пользователей.
	/// </summary>
    public interface IAuthenticationDataService
    {
		UserBase CreateUser(string login, string password);
		UserBase VerifyUser(string login, string password);
	}
}

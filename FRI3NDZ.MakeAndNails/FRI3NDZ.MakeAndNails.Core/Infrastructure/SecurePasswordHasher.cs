using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace FRI3NDZ.MakeAndNails.Core.Infrastructure
{
	/// <summary>
	/// Сервис хэширования паролей. Стырено с http://stackoverflow.com/a/32191537.
	/// </summary>
	public sealed class SecurePasswordHasher
	{
		/// <summary>
		/// Размер приправки.
		/// </summary>
		private const int SaltSize = 16;

		/// <summary>
		/// Размер хэша.
		/// </summary>
		private const int HashSize = 20;

		/// <summary>
		/// Захэшировать пароль.
		/// </summary>
		/// <param name="password">Пароль.</param>
		/// <param name="iterations">Количество итераций.</param>
		/// <returns>Хэш пароля.</returns>
		public static string Hash(string password, int iterations = 1000)
		{
			//create salt
			byte[] salt;
			RandomNumberGenerator.Create().GetBytes(salt = new byte[SaltSize]);

			//create hash
			var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations);
			var hash = pbkdf2.GetBytes(HashSize);

			//combine salt and hash
			var hashBytes = new byte[SaltSize + HashSize];
			Array.Copy(salt, 0, hashBytes, 0, SaltSize);
			Array.Copy(hash, 0, hashBytes, SaltSize, HashSize);

			//convert to base64
			var base64Hash = Convert.ToBase64String(hashBytes);

			//format hash with extra information
			return string.Format("$MYHASH$V1${0}${1}", iterations, base64Hash);
		}

		/// <summary>
		/// Проверить, а вообще валидный ли хэш.
		/// </summary>
		/// <param name="hashString">Хэш пароля.</param>
		/// <returns>Валидный ли хэш.</returns>
		public static bool IsHashSupported(string hashString)
		{
			return hashString.Contains("$MYHASH$V1$");
		}

		/// <summary>
		/// Проверить пароль и его хэш.
		/// </summary>
		/// <param name="password">Пароль.</param>
		/// <param name="hashedPassword">Хэш пароля.</param>
		/// <returns>Правильный ли хэш пароля.</returns>
		public static bool Verify(string password, string hashedPassword)
		{
			//check hash
			if (!IsHashSupported(hashedPassword))
			{
				throw new NotSupportedException("The hashtype is not supported");
			}

			//extract iteration and Base64 string
			var splittedHashString = hashedPassword.Replace("$MYHASH$V1$", "").Split('$');
			var iterations = int.Parse(splittedHashString[0]);
			var base64Hash = splittedHashString[1];

			//get hashbytes
			var hashBytes = Convert.FromBase64String(base64Hash);

			//get salt
			var salt = new byte[SaltSize];
			Array.Copy(hashBytes, 0, salt, 0, SaltSize);

			//create hash with given salt
			var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations);
			byte[] hash = pbkdf2.GetBytes(HashSize);

			//get result
			for (var i = 0; i < HashSize; i++)
			{
				if (hashBytes[i + SaltSize] != hash[i])
				{
					return false;
				}
			}
			return true;
		}
	}
}

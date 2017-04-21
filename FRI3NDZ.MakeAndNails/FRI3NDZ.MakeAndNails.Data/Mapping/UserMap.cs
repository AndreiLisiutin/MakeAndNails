using Dapper.FluentMap;
using Dapper.FluentMap.Dommel;
using Dapper.FluentMap.Dommel.Mapping;
using Dapper.FluentMap.Mapping;
using FRI3NDZ.MakeAndNails.Core.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FRI3NDZ.MakeAndNails.Data.Mapping
{
    /// <summary>
    /// Маппинг сущности пользователя со структурой в базе данных для Dommel + Dapper Fluent Configuration.
    /// </summary>
    public class UserBaseMap : DommelEntityMap<UserBase>
    {
        public UserBaseMap()
        {
            ToTable("user", "public");

            Map(p => p.Id)
                .IsKey()
                .IsIdentity()
                .ToColumn("user_id");
            Map(p => p.Name)
                .ToColumn("name");
			Map(p => p.Surname)
				.ToColumn("surname");
			Map(p => p.Patronymic)
				.ToColumn("patronymic");
			Map(p => p.Login)
				.ToColumn("login");
			Map(p => p.Email)
				.ToColumn("email");
			Map(p => p.PasswordHash)
				.ToColumn("password_hash");
			Map(p => p.CreatedOn)
				.ToColumn("created_on");
			Map(p => p.Phone)
				.ToColumn("phone");
		}
    }

	/// <summary>
	/// Маппинг сущности пользователя со структурой в базе данных для Dommel + Dapper Fluent Configuration.
	/// </summary>
	internal class UserMap : DommelEntityMap<User>
    {
        public UserMap()
            : base()
        {
			ToTable("user", "public");

			Map(p => p.Id)
				.IsKey()
				.IsIdentity()
				.ToColumn("user_id");
			Map(p => p.Name)
				.ToColumn("name");
			Map(p => p.Surname)
				.ToColumn("surname");
			Map(p => p.Patronymic)
				.ToColumn("patronymic");
			Map(p => p.Login)
				.ToColumn("login");
			Map(p => p.Email)
				.ToColumn("email");
			Map(p => p.PasswordHash)
				.ToColumn("password_hash");
			Map(p => p.CreatedOn)
				.ToColumn("created_on");
			Map(p => p.Phone)
				.ToColumn("phone");
		}
    }
    
}

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
    /// Маппинг тестовой сущности со структурой в базе данных для Dommel + Dapper Fluent Configuration.
    /// </summary>
    public class _TestEntityBaseMap : DommelEntityMap<_TestEntityBase>
    {
        public _TestEntityBaseMap()
        {
            ToTable("_test_entity");

            Map(p => p.Id)
                .IsKey()
                .IsIdentity()
                .ToColumn("_test_entity_id");
            Map(p => p.Name)
                .ToColumn("name");
            Map(p => p.Date)
                .ToColumn("date");
        }
    }

    /// <summary>
    /// Маппинг тестовой сущности со структурой в базе данных для Dommel + Dapper Fluent Configuration.
    /// </summary>
    internal class _TestEntityMap : DommelEntityMap<_TestEntity>
    {
        public _TestEntityMap()
            : base()
        {
            ToTable("_test_entity");

            Map(p => p.Id)
                .IsKey()
                .IsIdentity()
                .ToColumn("_test_entity_id");
            Map(p => p.Name)
                .ToColumn("name");
            Map(p => p.Date)
                .ToColumn("date");
        }
    }
    
}

using Dapper.FluentMap;
using Dapper.FluentMap.Dommel;
using FRI3NDZ.MakeAndNails.Data.Mapping;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FRI3NDZ.MakeAndNails.Data
{
    /// <summary>
    /// Конфигурация Fluent Mapping для всех сущностей проекта.
    /// </summary>
    public static class FluentMappingConfiguration
    {
        public static void ConfigureMapping()
        {
            FluentMapper.Initialize(config =>
            {
                config.AddMap(new _TestEntityMap());
                config.AddMap(new _TestEntityBaseMap());
                config.ForDommel();
            });
        }
    }
}

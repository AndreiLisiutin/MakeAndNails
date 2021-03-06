﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FRI3NDZ.MakeAndNails.Core.Models.Domain;
using FRI3NDZ.MakeAndNails.Core.Interfaces.Services.Data;

namespace FRI3NDZ.MakeAndNails.Web.Controllers
{
    /// <summary>
    /// Тестовый контроллер.
    /// </summary>
    [Route("api/_test")]
    public class _TestController : Controller
    {
		/// <summary>
		/// Конструктор тестового контроллера.
		/// </summary>
		/// <param name="_testDataService">Сервис данных для тестовой сущности.</param>
        public _TestController(I_TestDataService _testDataService)
        {
            this._TestDataService = _testDataService;
        }

		/// <summary>
		/// Сервис данных для тестовой сущности.
		/// </summary>
		public I_TestDataService _TestDataService { get; set; }

        /// <summary>
        /// Получить список тестовых сущностей.
        /// </summary>
        /// <returns>Список тестовых сущностей.</returns>
        [HttpGet()]
        [Route("all")]
        public List<_TestEntityBase> GetTestEntities()
        {
            return this._TestDataService.GetTestEntities();
        }
    }
}

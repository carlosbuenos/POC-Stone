using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entidades;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace PocApi.Controllers
{
	/// <summary>
	/// 
	/// </summary>
	[ApiController]
	[Route("[controller]")]
	public class WeatherForecastController : ControllerBase
	{
		private readonly IProcessaPagamento _processaPagamento;
		
		private static readonly string[] Summaries = new[]
		{
			"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
		};

		private readonly ILogger<WeatherForecastController> _logger;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="logger"></param>
		/// <param name="processaPagamento"></param>
		public WeatherForecastController(ILogger<WeatherForecastController> logger, IProcessaPagamento processaPagamento)
		{
			_logger = logger;
			_processaPagamento = processaPagamento;
		}


		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public IEnumerable<WeatherForecast> Get()
		{
			_processaPagamento.ExecutarProcessamento(new Pagamentos(TiposDePagamento.BradescoMasterCard, 30.65));
			var rng = new Random();
			return Enumerable.Range(1, 5).Select(index => new WeatherForecast
			{
				Date = DateTime.Now.AddDays(index),
				TemperatureC = rng.Next(-20, 55),
				Summary = Summaries[rng.Next(Summaries.Length)]
			})
			.ToArray();
		}
	}
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entidades;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PocApi.Assinaturas;
using PocApi.ModeloController;

namespace PocApi.Controllers
{
	/// <summary>
	/// 
	/// </summary>
	[Route("api/[controller]")]
	[ApiController]
	public class ProcessaPagamentoController : ControllerBase, IProcessaPagamentoAssinaturas
	{

		private readonly IProcessaPagamento _processarPagamento;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="processarPagamento"></param>
		public ProcessaPagamentoController(IProcessaPagamento processarPagamento)
		{
			_processarPagamento = processarPagamento;
		}

		/// <summary>
		/// Consultar um pagamento utilizando o código de rastreio gerado ao processar o pagamento.
		/// </summary>
		/// <param name="CodRastreio"></param>
		/// <returns></returns>
		[HttpGet]
		[Route("ConsultaPagamento/{CodRastreio}")]
		public string ConsultarPagamento(string CodRastreio)
		{
			return _processarPagamento.ConsultarStatusDoProcessamento(CodRastreio).Result;
		}

		/// <summary>
		/// Processar um pagamento
		/// Tipos de pagamento disponíveis
		/// BradescoMasterCard = 0,
		///	BradescoElo        = 1,
		/// BradescoVisa       = 2,
		/// ItauMasterCard     = 3,
		/// ItauVisa           = 4,
		/// ItauElo            = 5,
		/// ####################################################
		/// O atributo valor deve ser iinformado com "." ponto e não com "," virgula para separar a casa decimal
		/// </summary>
		/// <param name="pagamento"></param>
		/// <returns></returns>
		[HttpPost]
		[Route("ProcessarPagamento")]
		public string ProcessarPagamento([FromBody] PagamentoController pagamento)
		{
			var ret = _processarPagamento.ExecutarProcessamento(new Pagamentos(pagamento.tipoPagamento, pagamento.valor)).Result;
			return ret;
		}
	}
}
using System;
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
		private readonly IManipuladorPubSub _mensageria;
		/// <summary>
		/// 
		/// </summary>
		/// <param name="processarPagamento"></param>
		/// <param name="mensageria"></param>
		public ProcessaPagamentoController(IProcessaPagamento processarPagamento, IManipuladorPubSub mensageria)
		{
			_processarPagamento = processarPagamento;
			_mensageria = mensageria;
		}

		/// <summary>
		/// Consultar um pagamento
		/// </summary>
		/// <param name="CodRastreio"></param>
		/// <returns></returns>
		[HttpGet]
		[Route("ConsultaPagamento/{CodRastreio}")]
		public ICollection<string> ConsultarPagamento(string CodRastreio)
		{
			return _processarPagamento.ConsultarStatusDoProcessamento(_mensageria, CodRastreio).Result;
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
			return _processarPagamento.ExecutarProcessamento(_mensageria, new Pagamentos(pagamento.tipoPagamento, pagamento.valor)).Result;
		}
	}
}
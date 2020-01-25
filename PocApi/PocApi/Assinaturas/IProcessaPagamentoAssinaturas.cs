using Microsoft.AspNetCore.Mvc;
using PocApi.ModeloController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocApi.Assinaturas
{
	/// <summary>
	/// 
	/// </summary>
	public interface IProcessaPagamentoAssinaturas
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="CodRastreio"></param>
		/// <returns></returns>
		string ConsultarPagamento(string CodRastreio);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="pagamento"></param>
		/// <returns></returns>
		string ProcessarPagamento([FromBody] PagamentoController pagamento);
	}
}

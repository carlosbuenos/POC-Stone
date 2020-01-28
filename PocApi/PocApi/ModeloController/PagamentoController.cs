using Dominio.Entidades;
using Dominio.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocApi.ModeloController
{
	/// <summary>
	/// 
	/// </summary>
	public class PagamentoController
	{
		/// <summary>
		/// 
		/// </summary>
		public TiposDePagamento tipoPagamento { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public double valor { get; set; }
	}
}

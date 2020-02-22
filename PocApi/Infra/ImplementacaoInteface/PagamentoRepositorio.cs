using Dominio.Entidades;
using Dominio.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Infra.AcessoBaseDados.AcessoPostgres;
using Microsoft.EntityFrameworkCore;

namespace Infra.ImplementacaoInteface
{
	public abstract class PagamentoRepositorio : IPagamentoRepositorio
	{
		protected ContextoPostgres _DB;
		public PagamentoRepositorio(ContextoPostgres contexto)
		{
			_DB = contexto;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="codigoRastreio"></param>
		/// <returns></returns>
		public async Task<Pagamentos> ConsultarPagamentoProcessado(string codigoRastreio)
		{
			
			var pagamento = await _DB.Pagamentos.Where(x => x.rastreio.Equals(codigoRastreio)).FirstOrDefaultAsync();
			_DB.Dispose();
			return pagamento;
		}

		public async Task RegistrarProcessamento(Pagamentos _obj)
		{
			await _DB.Set<Pagamentos>().AddAsync(_obj);
			await _DB.SaveChangesAsync();
			_DB.Dispose();
		}
	}
}

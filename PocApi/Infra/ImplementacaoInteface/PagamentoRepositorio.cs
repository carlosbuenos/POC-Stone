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
	public abstract class PagamentoRepositorio : ContextoPostgres, IPagamentoRepositorio
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="codigoRastreio"></param>
		/// <returns></returns>
		public async Task<Pagamentos> ConsultarPagamentoProcessado(string codigoRastreio)
		{
			var pagamento = await Pagamentos.Where(x => x.rastreio.Equals(codigoRastreio)).FirstOrDefaultAsync();
			return pagamento;
		}

		public async Task RegistrarProcessamento(Pagamentos _obj)
		{
			await Set<Pagamentos>().AddAsync(_obj);
			await SaveChangesAsync();
		}
	}
}

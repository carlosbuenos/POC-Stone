using Dominio.Entidades;
using Dominio.Interfaces;
using Infra.AcessoBaseDados.AcessoMongo;
using System;
using MongoDB.Driver;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Infra.ImplementacaoInteface
{
	public abstract class PagamentoRepositorio : ContextoMongo, IPagamentoRepositorio
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="codigoRastreio"></param>
		/// <returns></returns>
		public async Task<Pagamentos> ConsultarPagamentoProcessado(string codigoRastreio)
		{
			var pagamento = await Pagamentos.FindAsync(x=>x.rastreio==codigoRastreio).Result.FirstOrDefaultAsync();
			return pagamento;
		}

		public async Task RegistrarProcessamento(Pagamentos _obj)
		{
			var listWrites = new List<WriteModel<Pagamentos>>();
			listWrites.Add(new InsertOneModel<Pagamentos>(_obj));
			await Pagamentos.BulkWriteAsync(listWrites, new BulkWriteOptions() { IsOrdered = false });
		}
	}
}

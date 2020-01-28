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
		
		public async Task<Pagamentos> ConsultarPagamentoProcessado(string codigoRastreio)
		{
			var pagamento = Pagamentos.AsQueryable().Where(w => w.rastreio == codigoRastreio).FirstOrDefault();
			return pagamento;
		}

		public async Task RegistrarProcessamento(Pagamentos _obj)
		{
			await Pagamentos.InsertOneAsync(_obj);
		}
	}
}

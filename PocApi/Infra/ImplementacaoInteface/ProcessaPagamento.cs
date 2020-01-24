using Dominio.Entidades;
using Dominio.Interfaces;
using Google.Cloud.BigQuery.V2;
using Infra.AcessoBaseDados;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infra.ImplementacaoInteface
{
	public class ProcessaPagamento : ManipuladorBigQuery<Pagamentos>, IProcessaPagamento
	{
		public ProcessaPagamento() : base()
		{

		}

		public override Task<string> AlterarRegsitro(Pagamentos _obj)
		{
			throw new NotImplementedException();
		}

		public override Task<string> ConsultarRegistro(string codRegistro)
		{
			throw new NotImplementedException();
		}

		public string ConsultarStatusDoProcessamento(string codPagamento)
		{
			throw new NotImplementedException();
		}

		public override  Task<string> ExcluirRegistro(Pagamentos _obj)
		{
			throw new NotImplementedException();
		}

		public async Task<string> ExecutarProcessamento(Pagamentos pagamento)
		{
			return await InserirRegistro(pagamento);
		}

		public override async Task<string> InserirRegistro(Pagamentos _obj)
		{
			await base._tabela.InsertRowAsync(new BigQueryInsertRow
			{
			    { "codPagamento", _obj.codPagamento },
				{ "tipoDePagamento", _obj.tipoDePagamento },
				{ "valor", _obj.valor },

			});
			return _obj.codPagamento;
		}
	}
}

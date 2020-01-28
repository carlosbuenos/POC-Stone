using Dominio.Entidades;
using Dominio.Interfaces;
using Google.Apis.Bigquery.v2.Data;
using Google.Cloud.BigQuery.V2;
using Infra.AcessoBaseDados;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infra.ImplementacaoInteface
{
	public class ProcessaPagamento : PagamentoRepositorio, IProcessaPagamento
	{

		public ProcessaPagamento()
		{

		}

		public async Task<string> ConsultarStatusDoProcessamento(string _codRastreio)
		{
			var retorno = await ConsultarPagamentoProcessado(_codRastreio);
			return retorno.statusPagamento;
		}


		public async Task<string> ExecutarProcessamento(Pagamentos pagamento)
		{
			pagamento.AtualizaStatusPagamento();
			pagamento.AtribuirCodigoRastreio("");
			await RegistrarProcessamento(pagamento);
			return "Pagamento processado consulte pelo codigo de rastreio: " + pagamento.rastreio;
		}

		//public override async Task InserirRegistro(Pagamentos _obj)
		//{

		//	await base._tabela.InsertRowAsync(new BigQueryInsertRow
		//	{
		//		{ "codPagamento", _obj.codPagamento },
		//		{ "tipoDePagamento", _obj.tipoDePagamento },
		//		{ "valor", _obj.valor },
		//		{ "statusPagamento", _obj.statusPagamento },
		//		{ "dataPagamento", _obj.dataPagamento },
		//		{ "rastreio", _obj.rastreio },
		//	});

		//}

	}
}

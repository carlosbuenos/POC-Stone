using Google.Cloud.BigQuery.V2;
using System.Threading.Tasks;

namespace Infra.AcessoBaseDados
{
	public abstract class ManipuladorBigQuery<T> where T : class
	{
		public BigQueryClient _cliente;
		private BigQueryDataset _dataSet;
		public BigQueryTable _tabela { get; private set; }

		public ManipuladorBigQuery()
		{
			CriarEstrutura("PocStone");
		}
		private void InstanciaBigqueryCliente()
		{
			if (_cliente == null)
			{
				_cliente =  BigQueryClient.Create("estudo-ci-cd");
			}
		}

		private void CriarDataSet(string nomeDataSet)
		{
			_dataSet =  _cliente.GetOrCreateDataset(nomeDataSet);
		}

		private void CriarTabela()
		{
			string nome = typeof(T).Name;
			_tabela =  _dataSet.GetOrCreateTable(nome, new FabricaDeEsquemasDeTabela().CriarEsquema(nome).Build());
		}

		private void CriarEstrutura(string nomeDataSet)
		{
			 InstanciaBigqueryCliente();
			 CriarDataSet(nomeDataSet);
			 CriarTabela();
		}

		public abstract Task InserirRegistro(T _obj);


	}
}

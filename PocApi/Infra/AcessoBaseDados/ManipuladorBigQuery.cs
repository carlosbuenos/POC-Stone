using Dominio.Interfaces;
using Google.Cloud.BigQuery.V2;
using Infra.AcessoBaseDados.ChaveSecretaGCP;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infra.AcessoBaseDados
{
	public abstract class ManipuladorBigQuery<T> where T : class
	{
		private BigQueryClient _cliente;
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
				var credenciais = AcessarChave.RetornarCredenciais();
				_cliente =  BigQueryClient.Create("estudo-ci-cd", credenciais);
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

		public abstract Task<string> AlterarRegsitro(T _obj);

		public abstract Task<string> ConsultarRegistro(string codRegistro);

		public abstract Task<string> ExcluirRegistro(T _obj);

		public abstract Task<string> InserirRegistro(T _obj);


	}
}

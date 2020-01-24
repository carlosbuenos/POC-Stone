using Google.Cloud.BigQuery.V2;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.AcessoBaseDados
{
	public class FabricaDeEsquemasDeTabela
	{
		public TableSchemaBuilder CriarEsquema(string nomeEsquema)
		{
			TableSchemaBuilder retornoEsquema;
			switch (nomeEsquema.ToUpper())
			{
				case "PAGAMENTOS":
					{
						retornoEsquema =new EsquemasDeTabela().Pagamentos();
						break;
					}
				default:
					retornoEsquema = new EsquemasDeTabela().Pagamentos();
					break;
			}
			return retornoEsquema;
		}
	}
}

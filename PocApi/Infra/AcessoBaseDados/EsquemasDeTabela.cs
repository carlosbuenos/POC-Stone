using Google.Cloud.BigQuery.V2;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.AcessoBaseDados
{
	public class EsquemasDeTabela
	{
		public TableSchemaBuilder Pagamentos()
		{
			return new TableSchemaBuilder
			{
				{ "codPagamento", BigQueryDbType.String },
				{ "tipoDePagamento", BigQueryDbType.String },
				{ "valor", BigQueryDbType.Numeric },
				{ "statusPagamento", BigQueryDbType.String },

        	};
		}
	}
}

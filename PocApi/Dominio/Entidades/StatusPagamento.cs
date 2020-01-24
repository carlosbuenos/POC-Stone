using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Dominio.Entidades
{
	public enum StatusPagamento
	{
		[Description("Falha na comunicação com a operadora.")]
		Falha =0,
		[Description("Pagamento efetuado com sucesso.")]
		Sucesso =1,
		[Description("Pagamento aguardando autorização.")]
		Pendente =2,
	}
}

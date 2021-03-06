﻿using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces
{
	public interface IProcessaPagamento
	{
		Task<string> ExecutarProcessamento(IManipuladorPubSub<Pagamentos> mensageria,Pagamentos pagamento);
		Task<string> ConsultarStatusDoProcessamento(IManipuladorPubSub<Pagamentos> mensageria,string codPagamento);
	}
}

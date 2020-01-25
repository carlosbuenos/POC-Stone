using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces
{
	public interface IProcessaPagamento
	{
		Task<string> ExecutarProcessamento(IManipuladorPubSub mensageria,Pagamentos pagamento);
		Task<ICollection<string>> ConsultarStatusDoProcessamento(IManipuladorPubSub mensageria,string codPagamento);
	}
}

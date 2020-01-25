using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces
{
	public interface IManipuladorPubSub
	{
		Task<string> EnviarMensagem(string mensagem);
		Task<ICollection<string>> LeituraMensagem(string rastreio);
	}
}

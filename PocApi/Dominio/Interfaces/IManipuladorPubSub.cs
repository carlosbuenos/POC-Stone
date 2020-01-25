using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces
{
	public interface IManipuladorPubSub<T> where T:class
	{
		Task<string> EnviarMensagem(string mensagem);
		Task<T> LeituraMensagem(string rastreio);
	}
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Interfaces
{
	public interface IPubSub
	{
		void EnviarMensagem(string mensagem);
		string LeituraMensagem();
	}
}

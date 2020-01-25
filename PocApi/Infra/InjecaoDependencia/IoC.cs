using Dominio.Interfaces;
using Infra.AcessoBaseDados;
using Infra.ImplementacaoInteface;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.InjecaoDependencia
{
	public class IoC
	{
		public static void CriarInjecoes(IServiceCollection servico)
		{
			servico.AddTransient<IProcessaPagamento, ProcessaPagamento>();
			servico.AddTransient<IManipuladorPubSub, ManipuladorPubSub>();
		}
	}
}

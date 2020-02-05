using Dominio.Interfaces;
using Infra.AcessoBaseDados;
using Infra.AcessoBaseDados.AcessoPostgres;
using Infra.ImplementacaoInteface;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.InjecaoDependencia
{
	public class IoC
	{
		public static void CriarInjecoes(IServiceCollection servico)
		{
			servico.AddScoped<ContextoPostgres>();
			servico.AddTransient<IProcessaPagamento, ProcessaPagamento>();
			
		}
	}
}

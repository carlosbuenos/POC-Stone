using Dominio.Entidades;
using System.Threading.Tasks;

namespace Dominio.Interfaces
{
	public interface IPagamentoRepositorio
	{
		Task<Pagamentos> ConsultarPagamentoProcessado(string codigoRastreio);
		Task RegistrarProcessamento(Pagamentos _obj);
	}
}

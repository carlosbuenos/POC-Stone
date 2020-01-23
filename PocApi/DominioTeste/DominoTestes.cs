using DominioTeste.Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DominioTeste
{
	[TestClass]
	public class DominoTestes
	{
		[TestMethod]
		public void ObjetoPagamentosNaoNulo()
		{
			PagamentosTeste pagamento = new PagamentosTeste(TiposDePagamentosTeste.BradescoElo, 23.50);
			Assert.IsNotNull(pagamento);
		}

		
	}
}

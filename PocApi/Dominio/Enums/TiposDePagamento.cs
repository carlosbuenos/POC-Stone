using System.ComponentModel;

namespace Dominio.Enums
{
	public enum TiposDePagamento
	{
		[Description("Bradesco MasterCard")]
		BradescoMasterCard = 0,
		[Description("Bradesco Elo")]
		BradescoElo = 1,
		[Description("Bradesco Visa")]
		BradescoVisa = 2,
		[Description("Itaú MasterCard")]
		ItauMasterCard = 3,
		[Description("Itaú Visa")]
		ItauVisa = 4,
		[Description("Itaú Elo")]
		ItauElo = 5
	}
}

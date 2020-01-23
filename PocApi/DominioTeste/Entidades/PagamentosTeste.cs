using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DominioTeste.Entidades
{
	public class PagamentosTeste
	{
		public PagamentosTeste(TiposDePagamentosTeste _TiposDePagamento, double _Valor)
		{
			codPagamento = GerarCodigoPagamento();
			tipoDePagamento = RetornaDescricaoDoTipoDePagamento(_TiposDePagamento);
			valor = _Valor;
		}
		public string codPagamento { get; private set; }
		public string tipoDePagamento { get; private set; }
		public double valor { get; private set; }

		public bool objetoEstaValido { get; private set; }
		private string GerarCodigoPagamento()
		{
			return Guid.NewGuid().ToString();
		}

		private string RetornaDescricaoDoTipoDePagamento(Enum value)
		{
			FieldInfo fi = value.GetType().GetField(value.ToString());

			DescriptionAttribute[] attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

			if (attributes != null && attributes.Any())
			{
				return attributes.First().Description;
			}

			return value.ToString();
		}
	}
}

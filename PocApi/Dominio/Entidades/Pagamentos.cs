using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Dominio.Entidades
{
	public class Pagamentos
	{
		public Pagamentos(TiposDePagamento _tiposDePagamento, double _valor)
		{
			codPagamento = GerarCodigoPagamento();
			tipoDePagamento = RetornaDescricao(_tiposDePagamento);
			valor = _valor;
			dataPagamento = RetornaDataFormatada(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

		}

		public string codPagamento { get; private set; }
		public string tipoDePagamento { get; private set; }
		public double valor { get; private set; }
		public string statusPagamento { get; private set; }
		public DateTime dataPagamento { get; private set; }
		public string rastreio { get; private set; }

		private string GerarCodigoPagamento()
		{
			return Guid.NewGuid().ToString().Replace("-", "").ToUpper();
		}
		private string RetornaDescricao(Enum _value)
		{
			FieldInfo fi = _value.GetType().GetField(_value.ToString());

			DescriptionAttribute[] attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

			if (attributes != null && attributes.Any())
			{
				return attributes.First().Description;
			}

			return _value.ToString();
		}
		private DateTime RetornaDataFormatada(string _data)
		{
			System.Globalization.CultureInfo cultureinfo = new System.Globalization.CultureInfo("en-us");
			DateTime dt = DateTime.Parse(_data, cultureinfo);
			return dt;
		}
		public void AtualizaStatusPagamento()
		{
			Array values = Enum.GetValues(typeof(StatusPagamento));
			Random random = new Random();
			var randomStatus = (StatusPagamento)values.GetValue(random.Next(values.Length));
			statusPagamento = RetornaDescricao(randomStatus);
		}
		public void AtribuirCodigoRastreio(string codRastreio)
		{
			rastreio = codRastreio;
		}

	}
}

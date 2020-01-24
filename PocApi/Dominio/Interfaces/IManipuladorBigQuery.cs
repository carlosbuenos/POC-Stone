using Google.Cloud.BigQuery.V2;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces
{
	public interface IManipuladorBigQuery<T> where T:class
	{
		Task<string> InserirRegistro(T _obj);
		Task<string> ConsultarRegistro(string _codRegistro);
		Task<string> AlterarRegsitro(T _obj);
		Task<string> ExcluirRegistro(T _obj);
	}
}

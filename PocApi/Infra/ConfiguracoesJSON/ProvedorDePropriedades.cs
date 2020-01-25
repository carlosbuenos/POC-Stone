using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Infra.ConfiguracoesJSON
{
	public class ProvedorDePropriedades: IValueProvider
	{
		PropertyInfo _pInfo;
		public ProvedorDePropriedades(PropertyInfo p)
		{
			_pInfo = p;
		}


		public void SetValue(object target, object value)
		{
			_pInfo.SetValue(target, value, null);
		}

		public object GetValue(object target)
		{
			return _pInfo.GetValue(target);
		}
	}
}

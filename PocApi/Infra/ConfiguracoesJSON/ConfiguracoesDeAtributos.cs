using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Infra.ConfiguracoesJSON
{
	public class ConfiguracoesDeAtributos: DefaultContractResolver
	{
		protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
		{
			var props = type.GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
						.Select(x => new Newtonsoft.Json.Serialization.JsonProperty()
						{
							PropertyName = x.Name,
							PropertyType = x.PropertyType,
							Readable = true,
							ValueProvider = new ProvedorDePropriedades(x),
							Writable = true
						})
						.ToList();


			return props;
		}
	}
}

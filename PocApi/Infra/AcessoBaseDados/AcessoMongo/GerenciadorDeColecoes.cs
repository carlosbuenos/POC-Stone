using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.AcessoBaseDados.AcessoMongo
{
	public class GerenciadorDeColecoes
	{
		public bool ColecaoExiste(MongoClient cliente, string _DatabaseName, string collectionName)
		{
			var listCollectionNames = cliente.GetDatabase(_DatabaseName).ListCollectionNames().ToList();
			foreach (var item in listCollectionNames)
			{
				if (item.Equals(collectionName))
				{
					return true;
				}
			}
			return false;
		}
	}
}

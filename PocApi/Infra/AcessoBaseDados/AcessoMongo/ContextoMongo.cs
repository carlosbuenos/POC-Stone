using Dominio.Entidades;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.AcessoBaseDados.AcessoMongo
{
	public abstract class ContextoMongo
	{
		private MongoClient _mongoCliente { get; set; }
		public IMongoDatabase _dbMongo { get; set; }
		public ContextoMongo()
		{
			_mongoCliente = new MongoClient($"mongodb://pocstone:pocstone@localhost");
			_dbMongo = _mongoCliente.GetDatabase("PocStone");

			if (!new GerenciadorDeColecoes().ColecaoExiste(_mongoCliente, "PocStone", "Pagamentos"))
			{
				_dbMongo.CreateCollection("Pagamentos");
			}
		}

		public IMongoCollection<Pagamentos> Pagamentos
		{
			get
			{
				return _dbMongo.GetCollection<Pagamentos>("Pagamentos");
			}
		}
	}
}

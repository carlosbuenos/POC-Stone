﻿using Dominio.Entidades;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.AcessoBaseDados.AcessoMongo
{
	public abstract class ContextoMongo
	{
		private MongoClient _mongoCliente { get; set; }
		private IMongoDatabase _dbMongo { get; set; }
		public ContextoMongo()
		{

			_mongoCliente = new MongoClient("mongodb://pocstone:pocstone@mongodb_server:27017");
			_dbMongo = _mongoCliente.GetDatabase("PocStone");

			if (!new GerenciadorDeColecoes().ColecaoExiste(_mongoCliente, "PocStone", "Pagamentos"))
			{
				_dbMongo.CreateCollection("Pagamentos");
				var collection = _dbMongo.GetCollection<Pagamentos>("Pagamentos");
				collection.Indexes.CreateOne(Builders<Pagamentos>.IndexKeys.Ascending(_ => _.codPagamento));
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
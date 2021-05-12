using System;
using System.Collections.Generic;
using System.Linq;
using Infrastructure.Database;
using Infrastructure.Database.Collections;
using MongoDB.Driver;
using Web.Models;

namespace Api.Repositories
{
    public class Repository : IRepository
    {
        private readonly IMongoConnect _mongoConnect;

        // private readonly IMongoCollection<Infectados> _CollectionInfectados;
        // private readonly IMongoCollection<Vacinados> _CollectionVacinados;
        private readonly FilterDefinition<Type> _filter;

        public Repository(IMongoConnect mongoConnect)
        {
            _mongoConnect = mongoConnect;
            //  _CollectionInfectados = _mongoConnect.db.GetCollection<Infectados>(typeof(Infectados).Name);
            // _CollectionVacinados = _mongoConnect.db.GetCollection<Vacinados>(typeof(Vacinados).Name);
            _filter = Builders<Type>.Filter.Empty;
        }
        public void Create<TDocument>(PessoaViewModelInput _pessoaViewModelInput)
        {
            var list = _mongoConnect.db.GetCollection<TDocument>(typeof(TDocument).Name);
            
            
            
        }

        public List<Type> GetAll()
        {
            return null;
        }
    }
}
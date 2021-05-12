using System;
using System.Collections.Generic;
using Infrasctructure.Database.Collections;
using Infrastructure.Database;
using MongoDB.Driver;
using Web.Models;

namespace Api.Repositories
{
    public class Repository : IRepository
    {
        private readonly IMongoConnect _mongoConnect;
        private readonly IMongoCollection<Pessoa> _List;
        private readonly FilterDefinition<Type> _filter;


        public Repository(IMongoConnect mongoConnect)
        {
            _mongoConnect = mongoConnect;
            _List = _mongoConnect.db.GetCollection<Pessoa>(typeof(Pessoa).Name);
            _filter = Builders<Type>.Filter.Empty;       
        }

        public void Create(Pessoa _pessoa)
        {
            try 
            {
                _List.InsertOne(_pessoa);
            }
            catch
            {
                throw new MongoException("Erro ao inserir informações no banco!");
            }
        }

        public List<Pessoa> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using Infrasctructure.Database.Collections;
using Infrastructure.Database;
using Infrastructure.Database.Connection;
using MongoDB.Driver;
using MongoDB.Driver.GeoJsonObjectModel;

namespace Api.Repositories
{
    public class Repository : IRepository
    {
        private const string Infectado = "Infectado";
        private const string Vacinado = "Vacinado";
        private readonly IMongoConnect _mongoConnect;
        private readonly IMongoCollection<Pessoa> _List;
        private readonly FilterDefinition<Pessoa> _filter;


        public Repository(IMongoConnect mongoConnect)
        {
            _mongoConnect = mongoConnect;
            _List = _mongoConnect.db.GetCollection<Pessoa>(typeof(Pessoa).Name);
            _filter = Builders<Pessoa>.Filter.Empty;  
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
            try
            {
                return _List.Find<Pessoa>(_filter).ToList();
            }
            catch
            {
                throw new MongoException("Erro ao inserir informações");
            }
        }

        public List<Pessoa> GetInfec()
        {
            try
            {
                return _List.Find<Pessoa>(Builders<Pessoa>.Filter.Where(p => p.TipoPessoa == Infectado)).ToList();
            }
            catch
            {
                throw new MongoException("Erro ao buscar informações");
            }
        }

        public List<Pessoa> GetVacin()
        {
            try
            {
                return _List.Find<Pessoa>(Builders<Pessoa>.Filter.Where(p => p.TipoPessoa == Vacinado)).ToList();
            }
            catch
            {
                throw new MongoException("Erro ao buscar informações");
            }
        }

        public List<GeoJson2DGeographicCoordinates> GetLocationsInfectados()
        {
            try
            {
                return _List.Find<Pessoa>(Builders<Pessoa>.Filter.Where(p => p.TipoPessoa == Infectado)).ToList().Select(p => p.Endereço.Coordenadas.Localização).ToList();
            }
            catch
            {
                throw new MongoException("Erro ao buscar informações");
            }
        }

        public List<Pessoa> GetLocations()
        {
            try
            {
                return _List.Find<Pessoa>(Builders<Pessoa>.Filter.Empty).ToList();
            }
            catch
            {
                throw new MongoException("Erro ao buscar informações");
            }
        }
    }
}
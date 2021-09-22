using System.Collections.Generic;
using System.Linq;
using Infrasctructure.Database.Collections;
using Infrastructure.Database;
using MongoDB.Driver;

namespace Api.Repositories
{
    public class Repository : IRepository
    {
        private const string Infectado = "Infectado";
        private const string Vacinado = "Vacinado";
        private readonly IMongoConnect _mongoConnect;
        private readonly IMongoCollection<Pessoa> _List;
        private readonly FilterDefinition<Pessoa> _filter;
        private readonly List<Pessoa> _ListaPessoas;
        private readonly List<Pessoa> _ListaInfectados;
        private readonly List<Pessoa> _ListaVacinados;


        public Repository(IMongoConnect mongoConnect)
        {
            _mongoConnect = mongoConnect;
            _List = _mongoConnect.db.GetCollection<Pessoa>(typeof(Pessoa).Name);
            _filter = Builders<Pessoa>.Filter.Empty;
            _ListaPessoas =  _List.Find<Pessoa>(_filter).ToList();
            _ListaInfectados = _ListaPessoas.Where(p => p.TipoPessoa == Infectado).ToList();
            _ListaVacinados = _ListaPessoas.Where(p => p.TipoPessoa == Vacinado).ToList();
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
                return _ListaPessoas;
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
                return _ListaInfectados;
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
                return _ListaVacinados;
            }
            catch
            {
                throw new MongoException("Erro ao buscar informações");
            }
        }
    
    }
}
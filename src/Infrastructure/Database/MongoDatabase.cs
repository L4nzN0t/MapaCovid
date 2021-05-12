using System;
using Infrastructure.Database.Collections;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Driver;

namespace Infrastructure.Database 
{
    public class MongoDatabase : IMongoConnect
    {
        public IMongoDatabase db {get;set;}
        public MongoDatabase(IConfiguration _configuration)
        {
            try
            {
                var _ConventionPack = new ConventionPack { new CamelCaseElementNameConvention() };
                ConventionRegistry.Register("camelCase",_ConventionPack, t => true);
                var _MongoDBClient = new MongoClient(_configuration.GetSection("ConnectionString").
                                            GetSection("DefaultConnection").Value.ToString());
                db = _MongoDBClient.GetDatabase(_configuration["NomeBanco"]);
                MappingClass();
            }
            catch (Exception e)
            {
                throw new MongoException("Erro ao conectar ao banco de dados!", e);
            }
        }

        void MappingClass()
        {
            
            BsonClassMap.RegisterClassMap<Coordenadas>();
            BsonClassMap.RegisterClassMap<Endereço>();
            
            if (!BsonClassMap.IsClassMapRegistered(typeof(Infectados)))
            {

                BsonClassMap.RegisterClassMap<Infectados>(x =>
                {
                    x.SetIgnoreExtraElements(true);
                    x.SetDiscriminator("Endereço");
                    x.MapIdField(i => i.Id).SetIsRequired(true).SetIdGenerator(ObjectIdGenerator.Instance);
                    x.MapField(i => i.Nome);
                    x.MapField(i => i.Sexo).SetIsRequired(true);
                    x.MapField(i => i.DataNascimento);
                    // x.MapField(i => i.Rua);
                    // x.MapField(i => i.Bairro);
                    // x.MapField(i => i.Cidade);
                    // x.MapField(i => i.Estado);
                    // x.MapField(i => i.Cep);
                    // x.MapField(i => i.Numero);
                    // x.MapField(i => i.Latitude).SetIsRequired(true);
                    // x.MapField(i => i.Longitude).SetIsRequired(true);
                });
            }
            
            if (!BsonClassMap.IsClassMapRegistered(typeof(Vacinados)))
            {
                BsonClassMap.RegisterClassMap<Vacinados>(x =>
                {
                    x.SetIgnoreExtraElements(true);
                    x.SetDiscriminator("Endereço");
                    x.MapIdField(i => i.Id).SetIsRequired(true).SetIdGenerator(ObjectIdGenerator.Instance);
                    x.MapField(i => i.Nome);
                    x.MapField(i => i.Sexo).SetIsRequired(true);
                    x.MapField(i => i.DataNascimento);
                    // x.MapField(i => i.Rua);
                    // x.MapField(i => i.Bairro);
                    // x.MapField(i => i.Cidade);
                    // x.MapField(i => i.Estado);
                    // x.MapField(i => i.Cep);
                    // x.MapField(i => i.Numero);
                    // x.MapField(i => i.Latitude).SetIsRequired(true);
                    // x.MapField(i => i.Longitude).SetIsRequired(true);

                });
            }
            
        }

        
    }
}
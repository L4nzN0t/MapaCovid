using Infrasctructure.Database.Collections;
using Infrastructure.Database.Collections;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;

namespace Infrastructure.Database
{
    public class MappingMongoDb
    {
        public static void Configure()
        {
            BsonClassMap.RegisterClassMap<Pessoa>(x => 
            {
                x.SetIgnoreExtraElements(true);
                x.MapIdProperty(i => i.Id).SetIsRequired(true).SetIdGenerator(ObjectIdGenerator.Instance);
                x.MapProperty(i => i.TipoPessoa).SetElementName("Tipo").SetIsRequired(true);
                x.MapProperty(i => i.Nome).SetElementName("Nome");
                x.MapProperty(i => i.Sexo).SetElementName("Sexo").SetIsRequired(true);
                x.MapProperty(i => i.DataNascimento).SetElementName("Data de Nascimento").SetIsRequired(true);
                x.MapProperty(i => i.Endereço).SetElementName("Endereço");
            });
        }
    }
}
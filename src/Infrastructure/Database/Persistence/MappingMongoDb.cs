using Infrasctructure.Database.Collections;
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
                x.SetDiscriminator("Endereço");
                x.MapIdMember(i => i.Id).SetIsRequired(true).SetIdGenerator(ObjectIdGenerator.Instance);
                x.MapMember(i => i.TipoPessoa).SetIsRequired(true);
                x.MapMember(i => i.Nome);
                x.MapMember(i => i.Sexo).SetIsRequired(true);
                x.MapMember(i => i.DataNascimento).SetIsRequired(true);
                x.MapMember(i => i.Endereço).SetIsRequired(true);
            });
        }
    }
}
using MongoDB.Bson.Serialization.Attributes;

namespace Infrastructure.Database.Collections
{
    [BsonDiscriminator]
    public class Endereço : Coordenadas
    {
        public string Rua {get;set;}
        public string Bairro {get;set;}
        public int Numero {get;set;}
        public int Cep {get;set;}
        public string Cidade {get;set;}
        public string Estado {get;set;}
        //public Coordenadas Coordenadas {get;set;}
    }
}
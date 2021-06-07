using System;
using Infrasctructure.Database.Collections;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Infrastructure.Database.Collections
{
    public class Endereço
    {
        [BsonElement("Rua")]
        public string Rua {get;set;}

        [BsonElement("Bairro")]
        public string Bairro {get;set;}

        [BsonElement("Numero")]
        public int Numero {get;set;}

        [BsonElement("Cep")]
        public string Cep {get;set;}

        [BsonElement("Cidade")]
        public string Cidade {get;set;}

        [BsonElement("Estado")]
        public string Estado {get;set;}

        [BsonElement("Coordenadas")]
        public Coordenadas Coordenadas {get;set;}
    }
}
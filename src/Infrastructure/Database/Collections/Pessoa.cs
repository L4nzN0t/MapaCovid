using System;
using Infrastructure.Database.Collections;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Infrasctructure.Database.Collections
{
    public class Pessoa
    {
        public ObjectId Id {get;set;}

        [BsonElement("Nome")]
        public string Nome {get;set;}

        [BsonElement("Sexo")]
        public string Sexo {get;set;}

        [BsonElement("Data de Nascimento")]
        public DateTime DataNascimento {get;set;}

        [BsonElement("Tipo")]
        public string TipoPessoa {get;set;}

        [BsonElement("Endereço")]
        public Endereço Endereço {get;set;}
        
    }
}
using System;
using MongoDB.Bson;

namespace Infrastructure.Database.Collections
{
    public class Vacinados : Endereço
    {
        public ObjectId Id {get;set;}
        public string Nome {get;set;}
        public string Sexo {get;set;}
        public DateTime DataNascimento {get;set;}
        //public Endereço Endereço {get;set;}
        
    }
}
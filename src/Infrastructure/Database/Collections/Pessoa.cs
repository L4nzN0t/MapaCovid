using System;
using Infrastructure.Database.Collections;
using MongoDB.Bson;

namespace Infrasctructure.Database.Collections
{
    public class Pessoa
    {
        public ObjectId Id {get;set;}
        public string Nome {get;set;}
        public string Sexo {get;set;}
        public DateTime DataNascimento {get;set;}
        public string TipoPessoa {get;set;}
        public Endereço Endereço {get;set;}
        
    }
}
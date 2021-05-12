using System;
using Infrastructure.Database.Collections;
using MongoDB.Bson;

namespace Infrasctructure.Database.Collections
{
    public class Pessoa : Endereço
    {
        public ObjectId Id {get;set;}
        public string Nome {get;set;}
        public string Sexo {get;set;}
        public DateTime DataNascimento {get;set;}
        public string TipoPessoa {get;set;}

        public Pessoa(string Nome, string Sexo, DateTime DataNascimento, string TipoPessoa)
        {
            this.Nome = Nome;
            this.Sexo = Sexo;
            this.DataNascimento = DataNascimento;
            this.TipoPessoa = TipoPessoa;
        }

    }
}
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

        public Pessoa(ObjectId id, string nome, string sexo, DateTime dataNascimento, string tipoPessoa)
        {
            try 
            {
            this.Id = id;
            this.Nome = nome;
            this.Sexo = sexo;
            this.DataNascimento = dataNascimento;
            this.TipoPessoa = tipoPessoa;
            this.Endereço = endereço;
            } 
            catch (InvalidCastException ex)
            {
                throw new InvalidCastException("Erro ao converter dados para inserçao no banco", ex);
            }
            
        }
    }
}
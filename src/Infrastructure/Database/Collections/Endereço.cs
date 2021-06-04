using System;
using Infrasctructure.Database.Collections;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Infrastructure.Database.Collections
{
    public class Endereço
    {
        public string Rua {get;set;}
        public string Bairro {get;set;}
        public int Numero {get;set;}
        public string Cep {get;set;}
        public string Cidade {get;set;}
        public string Estado {get;set;}
        public Coordenadas Coordenadas {get;set;}

        // public Endereço(string rua, string bairro, int numero, string cep, string cidade, string estado, double latitude, double longitude)
        // {
        //     this.Rua = rua;
        //     this.Bairro = bairro;
        //     this.Numero = numero;
        //     this.Cep = cep;
        //     this.Cidade = cidade;
        //     this.Estado = estado;
        //     this.Coordenadas = new Coordenadas(new MongoDB.Driver.GeoJsonObjectModel.GeoJson2DGeographicCoordinates(latitude, longitude));
        // }
    }
}
using MongoDB.Driver.GeoJsonObjectModel;

namespace Api.Models
{
    public class EndereçoViewModelInput
    {
        public string Rua {get;set;}
        public string Bairro {get;set;}
        public int Numero {get;set;}
        public int Cep {get;set;}
        public string Cidade {get;set;}
        public string Estado {get;set;}
        public CoordenadasViewModelInput coordenadasViewModelInput {get;set;}
    }
}
using System.ComponentModel.DataAnnotations;
using MongoDB.Driver.GeoJsonObjectModel;

namespace Api.Models
{
    public class EndereçoViewModelInput
    {
        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Rua {get;set;}

        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Bairro {get;set;}

        [Required(ErrorMessage = "Campo obrigatório!")]
        public int Numero {get;set;}

        [Required(ErrorMessage = "Campo obrigatório!")]
        public int Cep {get;set;}

        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Cidade {get;set;}

        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Estado {get;set;}
        
        [Required(ErrorMessage = "Campo obrigatório!")]
        public CoordenadasViewModelInput coordenadasViewModelInput {get;set;}
    }
}
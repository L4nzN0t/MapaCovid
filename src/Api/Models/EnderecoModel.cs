using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class EnderecoModel
    {
        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Rua { get; set; }
        

        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Bairro { get; set; }


        [Required(ErrorMessage = "Campo obrigatório!")]
        public int Numero { get; set; }


        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Cep { get; set; }


        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Cidade { get; set; }


        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Estado { get; set; }
    }
}
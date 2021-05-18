using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class PessoaViewModelInput
    {

        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Sexo { get; set; }
        
        [Required(ErrorMessage = "Campo obrigatório!")]
        public string TipoPessoa {get;set;}

        [Required(ErrorMessage = "Campo obrigatório!")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public EndereçoViewModelInput EndereçoViewModelInput { get; set; }

    }
}

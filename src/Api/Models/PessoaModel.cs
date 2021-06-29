using System;
using System.ComponentModel.DataAnnotations;
using Infrasctructure.Database.Collections;

namespace Api.Models
{
    public class PessoaModel
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
        public EnderecoModel EnderecoModel { get; set; }

        public static explicit operator Pessoa (PessoaModel pessoaModel)
        {
            Pessoa pessoa = new Pessoa();
            pessoa.Nome = pessoaModel.Nome;
            pessoa.Sexo = pessoaModel.Sexo;
            pessoa.DataNascimento = pessoaModel.DataNascimento;
            pessoa.TipoPessoa = pessoaModel.TipoPessoa;
            pessoa.Endereço = new Infrastructure.Database.Collections.Endereço();
            pessoa.Endereço.Rua = pessoaModel.EnderecoModel.Rua;
            pessoa.Endereço.Bairro = pessoaModel.EnderecoModel.Bairro;
            pessoa.Endereço.Numero = pessoaModel.EnderecoModel.Numero;
            pessoa.Endereço.Cep = pessoaModel.EnderecoModel.Cep;
            pessoa.Endereço.Cidade = pessoaModel.EnderecoModel.Cidade;
            pessoa.Endereço.Estado = pessoaModel.EnderecoModel.Estado;
            return pessoa;
        }
    }
}
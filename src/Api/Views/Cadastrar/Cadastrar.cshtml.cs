using System;
using System.ComponentModel.DataAnnotations;
using Api.Models;
using Infrasctructure.Database.Collections;

namespace Api.Views.Cadastrar
{
    public class CadastrarModel
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
        public CadastrarEnderecoModel EnderecoModel { get; set; }

        public static explicit operator Pessoa (CadastrarModel cadastrarModel)
        {
            Pessoa pessoa = new Pessoa();
            pessoa.Nome = cadastrarModel.Nome;
            pessoa.Sexo = cadastrarModel.Sexo;
            pessoa.DataNascimento = cadastrarModel.DataNascimento;
            pessoa.TipoPessoa = cadastrarModel.TipoPessoa;
            pessoa.Endereço = new Infrastructure.Database.Collections.Endereço();
            pessoa.Endereço.Rua = cadastrarModel.EnderecoModel.Rua;
            pessoa.Endereço.Bairro = cadastrarModel.EnderecoModel.Bairro;
            pessoa.Endereço.Numero = cadastrarModel.EnderecoModel.Numero;
            pessoa.Endereço.Cep = cadastrarModel.EnderecoModel.Cep;
            pessoa.Endereço.Cidade = cadastrarModel.EnderecoModel.Cidade;
            pessoa.Endereço.Estado = cadastrarModel.EnderecoModel.Estado;
            return pessoa;
        }
    }
}
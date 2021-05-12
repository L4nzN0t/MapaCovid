using System;
using Web.Models;

namespace Api.Services
{
    public interface IServiceDelegate
    {
        public delegate Type PersonTypeDelegate(PessoaViewModelInput pessoaViewModelInput);

        public static Type ReturnCollection(PessoaViewModelInput pessoaViewModelInput) 
        {
            return pessoaViewModelInput.TipoPessoa.GetType();
        }
    }
}
using System;
using Web.Models;

namespace Api.Services
{
    public interface IServiceRepository
    {
        void Adicionar(PessoaViewModelInput pessoaViewModelInput);
    }
}
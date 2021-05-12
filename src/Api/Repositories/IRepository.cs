using System;
using System.Collections.Generic;
using Web.Models;

namespace Api.Repositories
{
    public interface IRepository
    {
        void Create<TDocument>(PessoaViewModelInput _pessoaViewModelInput);
        List<Type> GetAll();
    }
}
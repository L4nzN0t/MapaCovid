using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Infrasctructure.Database.Collections;
using Web.Models;

namespace Api.Repositories
{
    public interface IRepository
    {
        void Create(Pessoa pessoa);
        List<Pessoa> GetAll();
    }
}
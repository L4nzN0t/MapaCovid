using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Infrasctructure.Database.Collections;

namespace Api.Repositories
{
    public interface IRepository
    {
        void Create(Pessoa pessoa);
        List<Pessoa> GetAll();
        List<Pessoa> GetInfec();
        List<Pessoa> GetVacin();
    }
}
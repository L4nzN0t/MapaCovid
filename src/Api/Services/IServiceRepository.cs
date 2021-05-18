
using System.Collections.Generic;
using Api.Models;
using Infrasctructure.Database.Collections;
using MongoDB.Driver.GeoJsonObjectModel;

namespace Api.Services
{
    public interface IServiceRepository
    {
        void Adicionar(PessoaViewModelInput pessoaViewModelInput);
        void RetornaTotalInfectados(out int infectados);
        void RetornaTotalVacinados(out int vacinados);
<<<<<<< HEAD
        double[][,] RetornaMapeamentoInfectados();
=======
        void RetornaMapeamentoInfectados();
>>>>>>> 2f5654e824bd19a4dbea6d1ce1143f18c38517e9

    }
}

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
        double[][,] RetornaMapeamentoInfectados();

    }
}
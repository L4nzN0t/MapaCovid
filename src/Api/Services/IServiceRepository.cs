
using System.Collections.Generic;
using Api.Models;
using Api.Views.Cadastrar;
using Infrasctructure.Database.Collections;
using MongoDB.Driver.GeoJsonObjectModel;

namespace Api.Services
{
    public interface IServiceRepository
    {
        void Adicionar(CadastrarModel cadastrarModel);
        void RetornaTotalInfectados(out int infectados);
        void RetornaTotalVacinados(out int vacinados);

    }
}
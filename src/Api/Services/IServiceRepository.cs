using System.Collections.Generic;
using Api.Models;

namespace Api.Services
{
    public interface IServiceRepository
    {
        void Adicionar(PessoaModel pessoaModel);
        void RetornaTotalInfectados(out int infectados);
        void RetornaTotalVacinados(out int vacinados);
        void RetornaCoordenadasInfectados(out double[][,] coordenadasInfectado);
        void RetornaCoordenadasVacinados(out double[][,] coordenadasVacinados);

    }
}
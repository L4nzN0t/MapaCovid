
using System.Collections.Generic;
using Infrasctructure.Database.Collections;

namespace Api.Services.Maps
{
    public interface IMapService
    {
        double[][,] coordenadasInfectados {get;set;}
        double[][,] coordenadasVacinados {get;set;}
        void ArrayLocations();
        void BuscarCoordenadasPorEndereço(ref Pessoa pessoa);
    }
}
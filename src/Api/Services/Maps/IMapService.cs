
namespace Api.Services.Maps
{
    public interface IMapService
    {
        double[][,] coordenadasInfectados {get;set;}
        double[][,] coordenadasVacinados {get;set;}
        void ArrayLocations();
    }
}
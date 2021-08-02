using Api.Services;
using Infrastructure.Database.Connection;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Api.Views.Home
{
    public class IndexModel : PageModel
    {
        private readonly IServiceRepository _service;
        public int _numeroInfectados, _numeroVacinados, _totalContabilizados;
        public double[][,] _coordenadasInfectados;
        public double[][,] _coordenadasVacinados;
        public double[] latitude;
        public double[] longitude;

        public IndexModel (IServiceRepository service)
        {
            if (TestMongoConnection.IsConnected)
            {
                _service = service;
                _service.RetornaTotalInfectados(out _numeroInfectados);
                _service.RetornaTotalVacinados(out _numeroVacinados);
                _service.RetornaCoordenadasInfectados(out _coordenadasInfectados);
                _service.RetornaCoordenadasInfectados(out _coordenadasVacinados);
                _totalContabilizados = SumOfAll();
            }
            else
            {
                _numeroInfectados = 0;
                _numeroVacinados = 0;
                _totalContabilizados = 0;
            }
            
        }

        private int SumOfAll()
        {
            return _numeroInfectados + _numeroVacinados;
        }

    }
}
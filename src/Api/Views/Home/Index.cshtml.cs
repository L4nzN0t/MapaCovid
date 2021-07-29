using Api.Services;
using Infrastructure.Database.Connection;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Api.Views.Home
{
    public class IndexModel : PageModel
    {
        private readonly IServiceRepository _service;
        public int _numeroInfectados, _numeroVacinados, _totalContabilizados;
        public double[][,] _coordenadas;
        public double[] latitude;
        public double[] longitude;

        public IndexModel (IServiceRepository service)
        {
            if (TestMongoConnection.IsConnected)
            {
                _service = service;
                _service.RetornaTotalInfectados(out _numeroInfectados);
                _service.RetornaTotalVacinados(out _numeroVacinados);
                _totalContabilizados = SumOfAll();
                //_coordenadas = _service.RetornaMapeamentoInfectados();
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

        public void LatLong()
        {
            int i = 0;
            foreach(var item in _coordenadas)
            {
                latitude[i] = item[0,0];
                longitude[i] = item[0,0];
            }
        }

    }
}
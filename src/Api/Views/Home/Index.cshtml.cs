using Api.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Api.Views.Home
{
    public class IndexModel : PageModel
    {
        private readonly IServiceRepository _service;
        public int _numeroInfectados;
        public int _numeroVacinados;
        public int _totalContabilizados;

        public IndexModel (IServiceRepository service)
        {
            _service = service;
            _service.RetornaTotalInfectados(out _numeroInfectados);
            _service.RetornaTotalVacinados(out _numeroVacinados);
            _totalContabilizados = SumOfAll();
        }

        private int SumOfAll()
        {
            return _numeroInfectados + _numeroVacinados;
        }

        public void ShowInfect()
        {
            _service.RetornaMapeamentoInfectados();
        }

        public void ShowVacin()
        {

        }

    }
}
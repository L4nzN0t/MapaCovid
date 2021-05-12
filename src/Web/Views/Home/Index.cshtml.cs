using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Web.Views.Home
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IServiceRepository _service;
        public int _numberInfectados;
        public int _numberVacinados;
        public int _totalContabilizados;

        public IndexModel(IServiceRepository service)
        {
            
        }

        public void OnGet()
        {

        }
    }
}

using Api.Services;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Api.Services.Maps;

namespace Api.Controllers
{
    [ApiController]
    public class HomeController : Controller
    {
        private readonly IServiceRepository _service;
        private readonly IMapService _mapService;
        public HomeController(IServiceRepository service, IMapService mapService)
        {
            _service = service;
            _mapService = mapService;
        }

        [Route("/")]
        [Route("/Home")]
        [Route("/Index")]
        public IActionResult Index()
        {
            IndexModel index = new IndexModel(_service);
            return View(index);    
        }
        
        [Route("/Home/Infectado")]
        public IActionResult Infectado()
        {
            IndexModel index = new IndexModel(_service);
            return View(index);
        }
    }
}
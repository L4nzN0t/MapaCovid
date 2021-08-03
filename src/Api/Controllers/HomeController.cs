using Api.Services;
using Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    public class HomeController : Controller
    {
        private readonly IServiceRepository _service;
        public HomeController(IServiceRepository service)
        {
            _service = service;
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
using Api.Services;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Api.Services.Maps;
using Infrastructure.Database.Connection;

namespace Api.Controllers
{
    [ApiController]
    public class HomeController : Controller
    {
        private readonly IServiceRepository _service;
        private readonly IMapService _mapService;
        public HomeController(IServiceRepository service, IMapService mapService)
        {
            if (TestMongoConnection.IsConnected)
            {
                _service = service;
                _mapService = mapService;
            } else {
                throw new System.Exception("MongoDB is not connected");
            }
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
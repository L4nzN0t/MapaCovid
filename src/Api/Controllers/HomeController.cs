using System;
using Api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Web.Views.Home;

namespace Api.Controllers
{
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
    }
}
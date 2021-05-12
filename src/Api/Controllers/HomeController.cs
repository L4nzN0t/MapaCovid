using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Web.Views.Home;

namespace Api.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
            
        }

        [Route("/")]
        [Route("/Home")]
        [Route("/Index")]
        public IActionResult Index()
        {
            IndexModel index = new IndexModel();
            return View(index);
        }
    }
}
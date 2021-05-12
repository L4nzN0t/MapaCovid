using System;
using Api.Services;
using Microsoft.AspNetCore.Mvc;
using Web.Models;


namespace _Api.Controllers
{
    [ApiController]
    public class CadastrarController : Controller
    {
        private readonly IServiceRepository _serviceRepository;
        
        public CadastrarController(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        [Route("/Cadastrar")]
        public IActionResult Cadastrar()
        {
            return View();    
        }

        [Route("/Cadastrar")]
        [HttpPost]
        public IActionResult Cadastrar([FromBody]PessoaViewModelInput pessoaViewModelInput)
        {
            try 
            {
                _serviceRepository.Adicionar();
            }
            catch
            {

            }
            
            return StatusCode(200,"Deu certo!");
        }
    }
}
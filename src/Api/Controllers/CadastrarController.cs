using System;
using Api.Models;
using Api.Services;
using Api.Views.Cadastrar;
using Microsoft.AspNetCore.Mvc;

namespace _Api.Controllers
{
    [ApiController]
    public class CadastrarController : Controller
    {
        private readonly IServiceRepository _service;
        
        public CadastrarController(IServiceRepository service)
        {
            _service = service;
        }

        [Route("/Cadastrar")]
        public IActionResult Cadastrar()
        {
            return View();    
        }

        [Route("/Cadastrar")]
        [HttpPost]
        public IActionResult Cadastrar([FromForm] CadastrarModel cadastrarModel)
        {
            try 
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                _service.Adicionar(cadastrarModel);
                return StatusCode(200,"Deu certo!");
            }
            catch (Exception ex)
            {
                return StatusCode(400,"Erro!");
                throw new Exception("Erro desconhecido!", ex);
            }
        }
    }
}
using System;
using Api.Models;
using Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace _Api.Controllers
{    
    public class CadastrarController : Controller
    {
        private readonly IServiceRepository _service;
        
        public CadastrarController(IServiceRepository service)
        {
            _service = service;
        }

        [Route("/Cadastrar")]
        public IActionResult CreateCadastrar()
        {
            return View();    
        }

        [HttpPost]
        [Route("/Cadastrar")]
        [ValidateAntiForgeryToken]
        public IActionResult CreateCadastrar([FromForm] PessoaModel pessoaModel)
        {
            try 
            {
                if (!ModelState.IsValid)
                {
                    return View(pessoaModel);
                }
                _service.Adicionar(pessoaModel);
                return Redirect("/Index");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
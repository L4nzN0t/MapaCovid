using System;
using System.Threading.Tasks;
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

        [HttpPost]
        [Route("/Cadastrar")]
        [ValidateAntiForgeryToken]
        public IActionResult Cadastrar([FromForm] CadastrarModel cadastrarModel)
        {
            try 
            {
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError(nameof(PessoaModel), "The erros are founded!");
                    return View(ModelState);
                }
                _service.Adicionar(cadastrarModel);
                return View("Views/Home/Index.cshtml");
            }
            catch (Exception ex)
            {
                return StatusCode(400,"Erro!");
                throw new Exception("Erro desconhecido!", ex);
            }
        }

        // [Route("/Cadastrar")]
        // [HttpPost]
        // public IActionResult Cadastrar([FromForm] CadastrarModel cadastrarModel)
        // {
        //     try 
        //     {
        //         if (!ModelState.IsValid)
        //         {
        //             return View(cadastrarModel);
        //         }
        //         _service.Adicionar(cadastrarModel);
        //         return View("Views/Home/Index.cshtml");
        //     }
        //     catch (Exception ex)
        //     {
        //         return StatusCode(400,"Erro!");
        //         throw new Exception("Erro desconhecido!", ex);
        //     }
        // }


    }
}
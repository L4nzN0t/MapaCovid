using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Api.Repositories;
using Api.Views.Cadastrar;
using Infrasctructure.Database.Collections;

namespace Api.Services
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly IRepository _repository; 
        public List<Pessoa> infectados;
        private double[][,] arrayCoordenates {get;set;}

        public ServiceRepository(IRepository repository)
        {
            _repository = repository;
        }

        public void Adicionar(CadastrarModel cadastrarModel) 
        {
            try 
            {
                
                Pessoa objPessoa = (Pessoa) cadastrarModel;
                _repository.Create(objPessoa);
            } 
            catch (JsonException ex)
            {
                throw new JsonException("Erro ao converter dados", ex);
            }
        }

        public void RetornaTotalInfectados(out int infectados)
        {
           var temp = _repository.GetInfec();
           infectados = temp.Count;
        }

        public void RetornaTotalVacinados(out int vacinados)
        {
            var temp = _repository.GetVacin();
            vacinados = temp.Count;
        }

        public double[][,] RetornaMapeamentoInfectados()
        {
            var list = _repository.GetLocations();
            var localizaçoes = list.Select(l => new
            {
                l.Latitude,
                l.Longitude
            }).ToList();
            int i = 0;
            foreach(var item in localizaçoes)
            {
                arrayCoordenates[i] = new double[,] {{item.Latitude, item.Longitude}};
                i++;
            }
            return arrayCoordenates;
        }

    }

    
}
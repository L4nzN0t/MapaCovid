using System;
using System.Collections.Generic;
using Api.Models;
using Api.Repositories;
using Api.Services.Maps;
using Infrasctructure.Database.Collections;

namespace Api.Services
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly IRepository _repository;
        private readonly IMapService _mapservice;

        public ServiceRepository(IRepository repository, IMapService mapService)
        {
            _repository = repository;
            _mapservice = mapService;
        }

        public void Adicionar(PessoaModel pessoaModel) 
        {
            try 
            {
                Pessoa objPessoa = (Pessoa) pessoaModel;
                _mapservice.BuscarCoordenadasPorEndereço(ref objPessoa);
                _repository.Create(objPessoa);
            } 
            catch (InvalidCastException ex)
            {
                throw new InvalidCastException("Erro ao converter dados", ex);
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

        public void RetornaCoordenadasInfectados(out double[][,] coordenadasInfectados)
        {
            var temp = _mapservice.coordenadasInfectados;
            coordenadasInfectados = temp;
        }

        public void RetornaCoordenadasVacinados(out double[][,] coordenadasVacinados)
        {
            var temp = _mapservice.coordenadasVacinados;
            coordenadasVacinados = temp;
        }

        
    }
}

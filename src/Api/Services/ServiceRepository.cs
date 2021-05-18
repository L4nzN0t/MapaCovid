using System;
using System.Collections.Generic;
using System.Linq;
using Api.Models;
using Api.Repositories;
using Infrasctructure.Database.Collections;
using MongoDB.Driver.GeoJsonObjectModel;
using Newtonsoft.Json;

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

        public void Adicionar(PessoaViewModelInput pessoaViewModelInput) 
        {
            try 
            {
                var json = JsonConvert.SerializeObject(pessoaViewModelInput);
                var obj = JsonConvert.DeserializeObject<Pessoa>(json);
                _repository.Create(obj);
            } 
            catch (JsonSerializationException ex)
            {
                throw new JsonSerializationException("Erro ao converter dados", ex);
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
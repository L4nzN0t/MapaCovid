using System.Collections.Generic;
using Api.Models;
using Api.Repositories;
using Infrasctructure.Database.Collections;
using Newtonsoft.Json;

namespace Api.Services
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly IRepository _repository; 
        public List<Pessoa> infectados;
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

    }

    
}
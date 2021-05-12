using Api.Repositories;
using Infrasctructure.Database.Collections;
using Newtonsoft.Json;
using Web.Models;

namespace Api.Services
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly IRepository _repository; 
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

    }

    
}
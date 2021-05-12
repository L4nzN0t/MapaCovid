using System;
using Api.Repositories;
using Infrastructure.Database.Collections;
using Web.Models;
using static Api.Services.IServiceDelegate;

namespace Api.Services
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly PersonTypeDelegate _predicatee;
        private readonly PessoaViewModelInput _pessoaViewModelInput;
        private readonly IRepository _repository; 
        public ServiceRepository(PessoaViewModelInput pessoaViewModelInput, IRepository repository)
        {
            _pessoaViewModelInput = pessoaViewModelInput;
            _predicatee = ReturnCollection;
            _repository = repository;
        }

        public Type PrepareToAdd()
        {
            return IServiceDelegate.ReturnCollection(_pessoaViewModelInput);
        }

        public void Adicionar() 
        {
            // Type _Type = PrepareToAdd();
            
            
            _repository.Create<Vacinados>(_pessoaViewModelInput);
            
        }

    }

    
}
using System;

namespace Api.Services
{
    public interface IServiceRepository
    {
        Type PrepareToAdd();
        void Adicionar();
    }
}
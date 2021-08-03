using System.Collections.Generic;
using System.Linq;
using Api.Repositories;
using Infrasctructure.Database.Collections;

namespace Api.Services.Maps
{
    public class MapService : IMapService
    {
        public double[][,] coordenadasInfectados {get;set;}
        public double[][,] coordenadasVacinados {get;set;}
        private readonly IRepository _repository;
        
        public MapService(IRepository repository)
        {
            _repository = repository;
            ArrayLocations();
        }

        public void ArrayLocations()
        {
            
            List<Pessoa> list = _repository.GetAll();
            var infectados = list.Where(p => p.TipoPessoa == "Infectado").ToList().Select(p => p.Endereço.Coordenadas.Localização).ToList();
            var vacinados = list.Where(p => p.TipoPessoa == "Vacinado").ToList().Select(p => p.Endereço.Coordenadas.Localização).ToList();

            var locInfectados = infectados.Select(l => new
            {
                l.Latitude,
                l.Longitude
            }).ToList();

            var locVacinados = vacinados.Select(l => new
            {
                l.Latitude,
                l.Longitude
            }).ToList();
            
            coordenadasInfectados = new double[locInfectados.Count][,];
            coordenadasVacinados = new double[locVacinados.Count][,];

            for (int x = 0; x < locInfectados.Count; x++)
            {
                coordenadasInfectados[x] = new double[,] {{locInfectados[x].Latitude, locInfectados[x].Longitude}};
                coordenadasVacinados[x] = new double[,] {{locVacinados[x].Latitude, locVacinados[x].Longitude}};
            }
        }   

    }
}
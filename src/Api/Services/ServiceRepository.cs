using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
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
        private readonly double[][,] _coordenates;

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
                BuscarCoordenadasPorEndereço(ref objPessoa);
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

        private void BuscarCoordenadasPorEndereço(ref Pessoa pessoa)
        {
            string apikey = ""; 
            string url = "https://maps.googleapis.com/maps/api/geocode/json?address={0}+{1}+{2},+{3},+{4}&oe=utf8&sensor=false&key={5}";
            
            string address = string.Format(url, pessoa.Endereço.Numero, pessoa.Endereço.Rua, pessoa.Endereço.Bairro,
                                                         pessoa.Endereço.Cidade, pessoa.Endereço.Estado, apikey);

            using (HttpClient clientHttp = new HttpClient())
            {
                var response = clientHttp.GetStringAsync(address);
                var result = response.Result.ToString();
                Newtonsoft.Json.Linq.JObject json = Newtonsoft.Json.Linq.JObject.Parse(result);
                
                var statuscode = json.SelectToken("status").ToString();
                if (statuscode == "OK")
                {
                    var lat = json.SelectToken("results[0].geometry.location.lat");
                    var longt = json.SelectToken("results[0].geometry.location.lng");
                    pessoa.Endereço.Coordenadas = new Infrastructure.Database.Collections.Coordenadas(
                            new MongoDB.Driver.GeoJsonObjectModel.GeoJson2DGeographicCoordinates(Convert.ToDouble(lat), Convert.ToDouble(longt)));

                } 
                else if (statuscode == "ZERO_RESULTS")
                {
                    // Nenhum resultado encontrado!;
                }
                else if (statuscode == "INVALID_REQUEST")
                {
                    // 
                }
                else if (statuscode == "UNKNOWN_ERROR")
                {
                    // Erro ao incluir localização
                }
                else
                {
                    // Erro fatal
                }

            }
            
        }
    }
}

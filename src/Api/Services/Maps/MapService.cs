using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using Api.Repositories;
using Infrasctructure.Database.Collections;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Api.Services.Maps
{
    public class MapService : IMapService
    {
        public double[][,] coordenadasInfectados {get;set;}
        public double[][,] coordenadasVacinados {get;set;}
        private readonly IRepository _repository;
        private readonly IConfiguration _configuration;
        
        public MapService(IConfiguration configuration, IRepository repository)
        {
            _configuration = configuration;
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

            string jsonResult = JsonConvert.SerializeObject(locInfectados);
            string path = $"C:/Development/Git/MapaCovid/src/Maps/locations.json";
            using (var tw = new StreamWriter(path, true))
            {
                tw.WriteLine(jsonResult.ToString());
                tw.Close();
            }
        }   

        public void BuscarCoordenadasPorEndereço(ref Pessoa pessoa)
        {
            string apikey = _configuration.GetSection("ApiKey").Value.ToString();
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
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using Api.Repositories;
using Api.Views.Cadastrar;
using Infrasctructure.Database.Collections;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
                BuscarCoordenadasPorEndereço(ref objPessoa);
                _repository.Create(objPessoa);
            } 
            catch (System.Text.Json.JsonException ex)
            {
                throw new System.Text.Json.JsonException("Erro ao converter dados", ex);
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

                JObject json = JObject.Parse(result);
                var location = json.SelectToken("results.geometry.location");
                var lat = location.Value<double>("lat");

            }

            
        }

    }

    
}

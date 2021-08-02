using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Infrasctructure.Database.Collections;
using MongoDB.Driver.GeoJsonObjectModel;

namespace Api.Repositories
{
    public interface IRepository
    {
        void Create(Pessoa pessoa);
        List<Pessoa> GetAll();
        List<Pessoa> GetInfec();
        List<Pessoa> GetVacin();
        List<GeoJson2DGeographicCoordinates> GetLocationsInfectados();
        List<Pessoa> GetLocations();
    }
}
using System;
using MongoDB.Bson;
using MongoDB.Driver.GeoJsonObjectModel;

namespace Infrastructure.Database.Collections
{
    public class Coordenadas
    {
        public GeoJson2DGeographicCoordinates Localização {get;set;}

        public Coordenadas(GeoJson2DGeographicCoordinates localização)
        {
            Localização = localização;
        }
    }
}
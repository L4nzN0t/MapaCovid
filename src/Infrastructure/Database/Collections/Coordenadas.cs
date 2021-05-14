using MongoDB.Driver.GeoJsonObjectModel;

namespace Infrastructure.Database.Collections
{
    public class Coordenadas
    {
        public GeoJson2DGeographicCoordinates Localização {get;set;}
    }
}
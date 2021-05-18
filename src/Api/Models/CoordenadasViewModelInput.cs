using MongoDB.Driver.GeoJsonObjectModel;

namespace Api.Models
{
    public class CoordenadasViewModelInput
    {
        public GeoJson2DGeographicCoordinates Localização {get;set;}
    }
}
using System.ComponentModel.DataAnnotations;
using MongoDB.Driver.GeoJsonObjectModel;

namespace Api.Models
{
    public class CoordenadasViewModelInput
    {
        [Required(ErrorMessage = "Campo obrigatório!")]
        public GeoJson2DGeographicCoordinates Localização {get;set;}
    }
}
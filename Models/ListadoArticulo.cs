using System.Text.Json.Serialization;

namespace WebApiCompras.Models
{
    public class ListadoArticulo
    {
        [JsonPropertyName("articulos")]
        public List<Articulos>? Articulos { get; set; }
    }
}

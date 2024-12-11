using System.Text.Json.Serialization;

namespace WebApiCompras.Models
{
    public class Articulos
    {
        [JsonPropertyName("codigo")]
        public string? Codigo { get;  set; }
        [JsonPropertyName("descripcion")]
        public string Descripcion { get;  set; }
        [JsonPropertyName("precio")]
        public decimal? Precio { get;  set; }
        [JsonPropertyName("deposito")]
        public int? Deposito { get; set; }
    }
}

namespace WebApiCompras.Models
{
    public class OrdenItem
    {
        public int ItemId { get; set; }
        public string Descripcion { get; set; }

        public decimal Precio { get; set; }

        public int Cantidad { get; set; }
    }
}

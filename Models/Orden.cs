namespace WebApiCompras.Models
{
    public class Orden
    {
        public int OrdenId { get; set; }
        public int VendedorId { get; set; }
        public List<OrdenItem> Items { get; set; }

    }
}

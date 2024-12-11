using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WebApiCompras.Models;

namespace WebApiCompras.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly IWebHostEnvironment _environment;

        public ProductoController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
        [HttpGet("articulos")]
        public IActionResult GetProducts()
        {

            string filePath = Path.Combine(_environment.ContentRootPath, "Data", "articulos.json");
            Console.WriteLine($"Ruta calculada: {filePath}");
    



            if (!System.IO.File.Exists(filePath))
                return NotFound(new { message = "Archivo de artículos no encontrado." });

        
            var jsonContent = System.IO.File.ReadAllText(filePath);
            var articulos = JsonSerializer.Deserialize<ListadoArticulo>(jsonContent)?.Articulos;

            
            Console.WriteLine($"Contenido del archivo: {jsonContent}");

            if (articulos == null)
                return BadRequest(new { message = "No se pudieron cargar los artículos." });

           
            var filtrarProductos = articulos
                //.Where(a => a.Deposito == 1) 
                //.Where(a => a.Precio > 0)   
                //.Where(a => IsValidDescription(a.Descripcion)) 
                .ToList();

            return Ok(filtrarProductos);
        }

        //private bool IsValidDescription(string description)
        //{
        //    return description.All(c => char.IsLetterOrDigit(c) || char.IsWhiteSpace(c));
        //}



        private static readonly List<Producto> Productos = new()
    {
        new Producto { Id = 1, Descripcion = "Notebook", Precio = 1500, Deposito = "1" },
        new Producto { Id = 2, Descripcion = "Celular", Precio = 15, Deposito = "2" },
        new Producto { Id = 3, Descripcion = "Teclado", Precio = 60, Deposito = "1" }
    };

        [HttpGet("{Producto}")]
        public IActionResult GetProducto()
        {
            var filteredProducts = Productos.Where(p => p.Deposito == "1" && p.Precio > 0).ToList();
            return Ok(filteredProducts);
        }






    }

    

}




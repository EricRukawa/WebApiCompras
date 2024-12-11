using Microsoft.AspNetCore.Mvc;
using WebApiCompras.Models;

namespace WebApiCompras.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidosController : ControllerBase
    {
        [HttpPost]
        public IActionResult CreateOrder([FromBody] Orden orden)
        {
            if (orden == null || orden.Items == null || !orden.Items.Any())
                return BadRequest(new { success = false, message = "Debe seleccionar al menos un artículo." });

            foreach (var item in orden.Items)
            {
                if (item.Precio <= 0)
                    return BadRequest(new { success = false, message = "Todos los precios deben ser mayores a 0." });

                if (item.Descripcion.Any(c => !char.IsLetterOrDigit(c) && !char.IsWhiteSpace(c)))
                    return BadRequest(new { success = false, message = "Las descripciones no pueden contener caracteres especiales." });
            }

            return Ok(new { success = true, message = "Pedido generado exitosamente." });
        }


    }
}

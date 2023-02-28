using Microsoft.AspNetCore.Mvc;
using WebApiCasas.Entidades;

namespace WebApiCasas.Controllers
{

    [ApiController]
    [Route("")]
    public class CasasController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Casa>> Get()
        {
            return new List<Casa>(){
            new Casa() { Id = 1, Num_casa = 200, Calle = "Magenta", Colonia = "Rosales", Cod_postal = 35600, Precio = 15000},
            new Casa() { Id = 2, Num_casa = 240, Calle = "Cerro", Colonia = "Juarez", Cod_postal = 55827, Precio = 25500 }
            };
        }
        
    }
}

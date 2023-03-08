using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiCasas.Entidades;

namespace WebApiCasas.Controllers
{

    [ApiController]
    [Route("casa")]
    public class CasasController : ControllerBase
    {

        private readonly AplicationDbContext dbContext;

        public CasasController(AplicationDbContext context)
        {
            this.dbContext = context;
        }

        [HttpGet]
        public ActionResult<List<Casa>> Get()
        {
            return new List<Casa>(){
            new Casa() { Id = 1, Num_casa = 200, Calle = "Magenta", Colonia = "Rosales", Cod_postal = 35600, Precio = 15000},
            new Casa() { Id = 2, Num_casa = 240, Calle = "Cerro", Colonia = "Juarez", Cod_postal = 55827, Precio = 25500 }
            };
        }

        [HttpPost]
        public async Task<ActionResult> Post(Casa casa)
        {
            dbContext.Add(casa);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("lista")]
        public async Task<ActionResult<List<Casa>>> GetAll()
        {
            return await dbContext.Casas.Include(x => x.familias).ToListAsync();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Casa casa, int id)
        {
            if (casa.Id != id)
            {
                return BadRequest("El Id de la casa no coincide con el establecido en la url.");
            }
            dbContext.Update(casa);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exist = await dbContext.Casas.AnyAsync(x => x.Id == id);
            if (!exist)
            {
                return NotFound("No se encontró el registro en la base de datos.");

            }

            dbContext.Remove(new Casa()
            {
                Id = id
            });
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}

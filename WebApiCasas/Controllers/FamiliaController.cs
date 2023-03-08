using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiCasas.Entidades;

namespace WebApiCasas.Controllers
{
    [ApiController]
    [Route("familia")]
    public class FamiliaController : ControllerBase
    {
        private readonly AplicationDbContext _context;

        public FamiliaController(AplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Familia>>> GetAll()
        {
            return await _context.Familias.ToListAsync();
        }

        [HttpGet("{id:int}")]

        public async Task<ActionResult<Familia>> GetById(int id)
        {
            return await _context.Familias.FirstOrDefaultAsync(x => x.Id == id);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Familia familia)
        {

            var existeCasa = await _context.Casas.AnyAsync(x => x.Id == familia.CasaId);

            if(!existeCasa)
            {
                return BadRequest("No existe la casa.");
            }

            _context.Add(familia);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]

        public async Task<ActionResult> Put(Familia familia, int id)
        {
            var existeFam = await _context.Familias.AnyAsync(x => x.Id == familia.CasaId);

            if (!existeFam)
            {
                return BadRequest("No existe la familia.");
            }

            if (familia.Id != id)
            {
                return BadRequest("El id de la familia no coincide con el establecido en la url");
            }

            _context.Update(familia);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exist = await _context.Familias.AnyAsync(x => x.Id == id);
            if (!exist)
            {
                return NotFound("No se encontró el registro en la base de datos.");

            }

            _context.Remove(new Familia()
            {
                Id = id
            });
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}

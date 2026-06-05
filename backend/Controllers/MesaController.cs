using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using backend.Data;
using backend.Dtos;
using backend.Models;

namespace backend.Controllers
{
    [ApiController]
    [Route("mesa")]
    public class MesaController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public MesaController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> AddMesa(Mesa mesa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _appDbContext.Mesa.Add(mesa);
                await _appDbContext.SaveChangesAsync();
                return CreatedAtAction(nameof(GetMesa), new { id = mesa.MesaID }, mesa);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mesa>>> GetAllMesas()
        {
            var mesas = await _appDbContext.Mesa.ToListAsync();
            return Ok(mesas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMesa(int id)
        {
            var _mesa = await _appDbContext.Mesa.FindAsync(id);
            if (_mesa == null)
            {
                return NotFound("Mesa não encontrada.");
            }
            return Ok(_mesa);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMesa(int id, Mesa mesa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (mesa.MesaID != id)
            {
                return BadRequest("O id da mesa está incorreto.");
            }

            var _mesa = await _appDbContext.Mesa.FindAsync(id);

            if(_mesa == null)
            {
                return NotFound("Mesa não encontrada.");
            }

            _appDbContext.Entry(_mesa).CurrentValues.SetValues(mesa);
            await _appDbContext.SaveChangesAsync();
            return NoContent();
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchMesa(int id, Mesa mesa)
        {
            var _mesa = await _appDbContext.Mesa.FindAsync(id);
            if (_mesa == null)
            {
                return NotFound("Mesa não encontrada.");
            }
            if (_mesa.Capacidade != mesa.Capacidade) { _mesa.Capacidade = mesa.Capacidade; }
            if (_mesa.Disponibilidade != mesa.Disponibilidade) { _mesa.Disponibilidade = mesa.Disponibilidade; }

            await _appDbContext.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMesa(int id)
        {
            var _mesa = await _appDbContext.Mesa.FindAsync(id);
            if(_mesa == null)
            {
                return NotFound("Mesa não encontrada.");
            }
            _appDbContext.Remove(_mesa);
            await _appDbContext.SaveChangesAsync();
            return NoContent();
        }

    }
}
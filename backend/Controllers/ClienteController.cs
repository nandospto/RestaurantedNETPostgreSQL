using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using backend.Data;
using backend.Models;


namespace backend.Controllers
{
    [ApiController]
    [Route("cliente")]
    public class ClienteController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public ClienteController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        [HttpPost()]
        public async Task<IActionResult> AddCliente(Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _appDbContext.Cliente.Add(cliente);
                await _appDbContext.SaveChangesAsync();
                return CreatedAtAction(nameof(GetCliente), new { id = cliente.ClienteID }, cliente);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet()]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetAllClientes()
        {
            try
            {
                var clientes = await _appDbContext.Cliente.ToListAsync();

                return Ok(clientes);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCliente(int id)
        {
            var _cliente = await _appDbContext.Cliente.FindAsync(id);
            if (_cliente == null)
            {
                return NotFound("Cliente não encontrado.");
            }
            return Ok(_cliente);

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCliente(int id, [FromBody] Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (cliente.ClienteID != id)
            {
                return BadRequest("O id do cliente está incorreto.");
            }
            var _cliente = await _appDbContext.Cliente.FindAsync(id);
            if (_cliente == null)
            {
                return NotFound("Cliente não encontrado.");
            }
            _appDbContext.Entry(_cliente).CurrentValues.SetValues(cliente);
            await _appDbContext.SaveChangesAsync();
            return NoContent();
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchCliente(int id, [FromBody] Cliente cliente)
        {
            var _cliente = await _appDbContext.Cliente.FindAsync(id);
            if (_cliente == null)
            {
                return NotFound("Cliente não encontrado.");
            }
            if (cliente.Nome != null && cliente.Nome != _cliente.Nome) { _cliente.Nome = cliente.Nome; }
            if (cliente.Telefone != null) { _cliente.Telefone = cliente.Telefone; }
            if (cliente.Email != null) { _cliente.Email = cliente.Email; }

            await _appDbContext.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            var _cliente = await _appDbContext.Cliente.FindAsync(id);
            if (_cliente == null)
            {
                return NotFound("Cliente não encontrado.");
            }
            _appDbContext.Remove(_cliente);
            await _appDbContext.SaveChangesAsync();
            return NoContent();
        }
    }
}
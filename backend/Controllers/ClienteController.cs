using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using backend.Data;
using backend.Models;
using backend.Dtos;


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

        [HttpPost]
        public async Task<ActionResult<Clientes>> AddCliente([FromBody] CriarClienteDTO cliente)
        {
            try
            {
                var _cliente = new Clientes()
                {
                    Nome = cliente.Nome == null ? "Anônimo" : cliente.Nome,
                    Telefone = cliente.Telefone,
                    Email = cliente.Email
                };

                _appDbContext.Clientes.Add(_cliente);
                await _appDbContext.SaveChangesAsync();
                
                return Ok(_cliente);
            }
            catch { return BadRequest(); }

        }
    }
}
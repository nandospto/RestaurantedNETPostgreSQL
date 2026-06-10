using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using backend.Dtos.Clientes;
using backend.Models;
using backend.Data;

namespace backend.Controllers
{
    [ApiController]
    [Route("clientes")]
    public class ClientesController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public ClientesController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteListaDTO>>> GetAllClientes()
        {
            try
            {
                var cliente = _appDbContext.Clientes
                .Select(c => new ClienteListaDTO
                {
                    ClientesID = c.ClientesID,
                    Nome = c.Nome != null ? c.Nome : "Anônimo"
                }).ToListAsync();
                return Ok(cliente);
            }
            catch
            {
                return BadRequest("Erro ao buscar clientes.");
            }
        }

        [HttpPost]
        public async Task<ActionResult<ClienteCriadoDTO>> AddCliente([FromBody] Clientes cliente)
        {
            try
            {
                var _cliente = new Clientes
                {
                    Nome = cliente.Nome != null ? cliente.Nome : "Anônimo",
                    Telefone = cliente.Telefone,
                    Email = cliente.Email
                };
                _appDbContext.Clientes.Add(_cliente);
                await _appDbContext.SaveChangesAsync();                

                return Ok(_cliente);

            }
            catch
            {
                return BadRequest("Erro ao adicionar cliente.");
            }
        }

    }
}
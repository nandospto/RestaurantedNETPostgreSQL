using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using backend.Data;
using backend.Dtos;
using backend.Models;

namespace backend.Controllers
{
    [ApiController]
    [Route("pedido")]
    public class PedidoController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public PedidoController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        private PedidoResponseDto ToPedidoResponseDto(Pedido pedido)
        {
            return new PedidoResponseDto
            {
                PedidoID = pedido.PedidoID,
                Descricao = pedido.Descricao,
                Datapedido = pedido.Datapedido,
                Status = pedido.Status,
                ClienteID = pedido.ClienteID,
                MesaID = pedido.MesaID
            };
        }

        private async Task<bool> ClienteExistsAsync(int clienteId)
        {
            return await _appDbContext.Cliente.AnyAsync(c => c.ClienteID == clienteId);
        }

        private async Task<bool> MesaExistsAsync(int mesaId)
        {
            return await _appDbContext.Mesa.AnyAsync(m => m.MesaID == mesaId);
        }

        [HttpPost]
        public async Task<IActionResult> AddPedido([FromBody] PedidoPatchDto pedido)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!pedido.ClienteID.HasValue || !pedido.MesaID.HasValue)
            {
                return BadRequest("ClienteID e MesaID são obrigatórios.");
            }

            if (!await ClienteExistsAsync(pedido.ClienteID.Value))
            {
                return BadRequest("Cliente não encontrado.");
            }

            if (!await MesaExistsAsync(pedido.MesaID.Value))
            {
                return BadRequest("Mesa não encontrada.");
            }

            var _pedido = new Pedido
            {
                Descricao = pedido.Descricao,
                Datapedido = DateTime.UtcNow,
                Status = pedido.Status ?? false,
                ClienteID = pedido.ClienteID.Value,
                MesaID = pedido.MesaID.Value,
                PedidosItensMenus = new List<PedidosItensMenu>()
            };

            _appDbContext.Pedido.Add(_pedido);
            await _appDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPedido), new { id = _pedido.PedidoID }, ToPedidoResponseDto(_pedido));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PedidoResponseDto>>> GetAllPedidos()
        {
            var pedidosDto = await _appDbContext.Pedido
                .Select(p => new PedidoResponseDto
                {
                    PedidoID = p.PedidoID,
                    Descricao = p.Descricao,
                    Datapedido = p.Datapedido,
                    Status = p.Status,
                    ClienteID = p.ClienteID,
                    MesaID = p.MesaID
                })
                .ToListAsync();

            return Ok(pedidosDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPedido(int id)
        {
            var _pedido = await _appDbContext.Pedido.FindAsync(id);
            if (_pedido == null)
            {
                return NotFound("Pedido não encontrado.");
            }

            return Ok(ToPedidoResponseDto(_pedido));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePedido(int id, [FromBody] Pedido pedido)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (pedido.PedidoID != id)
            {
                return BadRequest("O id do Pedido está incorreto.");
            }

            var _pedido = await _appDbContext.Pedido.FindAsync(id);
            if (_pedido == null)
            {
                return NotFound("Pedido não encontrado.");
            }

            if (!await ClienteExistsAsync(pedido.ClienteID))
            {
                return BadRequest("Cliente não encontrado.");
            }

            if (!await MesaExistsAsync(pedido.MesaID))
            {
                return BadRequest("Mesa não encontrada.");
            }

            _appDbContext.Entry(_pedido).CurrentValues.SetValues(pedido);
            await _appDbContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchPedido(int id, [FromBody] PedidoPatchDto pedido)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var _pedido = await _appDbContext.Pedido.FindAsync(id);
            if (_pedido == null)
            {
                return NotFound("Pedido não encontrado.");
            }

            if (pedido.ClienteID.HasValue && !await ClienteExistsAsync(pedido.ClienteID.Value))
            {
                return BadRequest("Cliente não encontrado.");
            }

            if (pedido.MesaID.HasValue && !await MesaExistsAsync(pedido.MesaID.Value))
            {
                return BadRequest("Mesa não encontrada.");
            }

            if (pedido.Descricao != null)
            {
                _pedido.Descricao = pedido.Descricao;
            }

            if (pedido.Status.HasValue)
            {
                _pedido.Status = pedido.Status.Value;
            }

            if (pedido.ClienteID.HasValue)
            {
                _pedido.ClienteID = pedido.ClienteID.Value;
            }

            if (pedido.MesaID.HasValue)
            {
                _pedido.MesaID = pedido.MesaID.Value;
            }

            await _appDbContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePedido(int id)
        {
            var _pedido = await _appDbContext.Pedido.FindAsync(id);
            if (_pedido == null)
            {
                return NotFound("Pedido não encontrado.");
            }

            _appDbContext.Remove(_pedido);
            await _appDbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
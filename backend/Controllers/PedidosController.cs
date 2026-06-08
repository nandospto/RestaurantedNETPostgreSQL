using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using backend.Data;
using backend.Dtos;
using backend.Models;

namespace backend.Controllers
{
    [ApiController]
    [Route("pedidos")]
    public class PedidosController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public PedidosController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        //////////////////////////////////
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PedidoMinificadoDTO>>> GetAllPedidos()
        {
            try
            {
                var pedidos = await _appDbContext.Pedidos
                    .Select(p => new PedidoMinificadoDTO
                    {
                        PedidosID = p.PedidosID,
                        ClienteNome = p.Clientes.Nome != null ? p.Clientes.Nome : "Anônimo",
                        DataPedido = p.DataPedido,
                        StatusPedido = p.StatusPedido,
                        TipoPedido = p.TipoPedido,
                        ValorTotal = p.ValorTotal
                    })
                    .ToListAsync();

                return Ok(pedidos);
            }
            catch
            {
                return BadRequest("Erro ao buscar pedidos.");
            }
        }
        //////////////////////////////////
        [HttpGet("{id}")]
        public async Task<ActionResult<Pedidos>> GetPedido(int id)
        {
            try
            {
                var pedido = await _appDbContext.Pedidos
                    .Where(p => p.PedidosID == id)
                    .Select(p => new PedidoDetalhadoDTO
                    {
                        PedidosID = p.PedidosID,
                        DataPedido = p.DataPedido,
                        StatusPedido = p.StatusPedido,
                        TipoPedido = p.TipoPedido,
                        ValorTotal = p.ValorTotal,

                        ClienteNome = p.Clientes.Nome != null ? p.Clientes.Nome : "Anônimo",
                        ClienteTelefone = p.Clientes.Telefone,
                        Endereco = p.TipoPedido == "Delivery" && p.Endereco != null ? p.Endereco.EnderecoCompleto : "Endereço não informado",
                        MesaID = p.Mesa != null ? p.Mesa.MesaID : null,
                        PedidosItensMenus = p.PedidosItensMenus.Select(pi => new ItemPedidoDTO
                        {
                            NomeItem = pi.ItensMenu.Nome,
                            Quantidade = pi.Quantidade,
                            Precounit = pi.PrecoUnit,
                        }).ToList()
                    })
                    .FirstOrDefaultAsync();

                return Ok(pedido);
            }
            catch
            {
                return NotFound("Erro ao buscar pedidos.");
            }
        }
        [HttpPost]
        public async Task<ActionResult<Pedidos>> AddPedido([FromBody] CriarPedidoDTO pedido)
        {
            // Verifica se há itens no pedido
            if (pedido.PedidosItensMenu == null) return BadRequest("O pedido deve conter pelo menos um item.");

            // Lista (com ID) todos os itens do pedido
            var ItensID = pedido.PedidosItensMenu.Select(i => i.ItensMenuID).Distinct().ToList();

            // Procura na database todos os itens do pedido que estão ativos e retorna o ID e o preço de cada um.
            var ItensMenu = await _appDbContext.ItensMenu
            .Where(i => ItensID.Contains(i.ItensMenuID) && i.Ativo)
            .ToDictionaryAsync(i => i.ItensMenuID, i => i.Preco);

            // Verifica se não há itens inativos no pedido
            if (ItensMenu.Count() != ItensID.Count()) return BadRequest("Um ou mais itens informados são inválidos ou estão inativos.");

            // Verifica se há cliente no BD com o nome e telefone parecidos.
            var clienteExiste = await _appDbContext.Clientes.Where(c => c.Nome == pedido.ClienteNome && c.Telefone == pedido.ClienteTelefone).Select(c => c.ClientesID).FirstOrDefaultAsync();

            // Se há, passa o ID para o pedido
            if (clienteExiste != 0)
            {
                pedido.ClientesID = clienteExiste;
            }

            // Se não há, cria um novo cliente
            else
            {
                var _clientes = new Clientes
                {
                    Nome = string.IsNullOrWhiteSpace(pedido.ClienteNome) ? "Anônimo" : pedido.ClienteNome,
                    Telefone = string.IsNullOrWhiteSpace(pedido.ClienteTelefone) ? "Telefone não informado" : pedido.ClienteTelefone
                };
                _appDbContext.Clientes.Add(_clientes);
                await _appDbContext.SaveChangesAsync();

                pedido.ClientesID = _clientes.ClientesID;
            }

            // Cria o pedido
            var _pedido = new Pedidos
            {
                ClientesID = (int)pedido.ClientesID,
                DataPedido = DateTime.Now,
                TipoPedido = pedido.TipoPedido,
                ValorTotal = pedido.PedidosItensMenu.Sum(i => ItensMenu[i.ItensMenuID] * i.Quantidade)
            };
            // Adiciona a lista de itens do DTO ao pedido no BD
            foreach (var itemDto in pedido.PedidosItensMenu)
            {
                _pedido.PedidosItensMenus.Add(new PedidosItensMenu
                {
                    PedidoID = _pedido.PedidosID,
                    ItensMenuID = itemDto.ItensMenuID,
                    Quantidade = itemDto.Quantidade,
                    PrecoUnit = ItensMenu[itemDto.ItensMenuID]
                });
            }

            _appDbContext.Pedidos.Add(_pedido);
            await _appDbContext.SaveChangesAsync();
            return Ok(_pedido);
        }
    }
}
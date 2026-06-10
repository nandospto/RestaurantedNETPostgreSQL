using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using backend.Dtos.ItensMenu;
using backend.Models;
using backend.Data;

namespace backend.Controllers
{
    [ApiController]
    [Route("itensmenu")]
    public class ItensMenuController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public ItensMenuController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItensMenuDTO>>> GetAllItensMenu()
        {
            try
            {
                var itensMenu = await _appDbContext.ItensMenu
                .Where(i => i.Ativo).ToListAsync();

                return Ok(itensMenu);
            }
            catch
            {
                return BadRequest("Erro ao buscar itens do menu.");
            }
        }

        [HttpPost]
        public async Task<ActionResult<ItensMenu>> AddItemMenu([FromBody] ItensMenuDTO item)
        {
            try
            {
                if(string.IsNullOrWhiteSpace(item.Nome)) return BadRequest("Nome é obrigatório.");
                var _item = new ItensMenu
                {
                    Nome = item.Nome,
                    Descricao = item.Descricao,
                    Preco = item.Preco
                };

                _appDbContext.ItensMenu.Add(_item);
                await _appDbContext.SaveChangesAsync();
                return Ok(item);

            }
            catch
            {
                return BadRequest("Erro ao adicionar item ao menu.");
            }
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> AtualizarItemMenu(int id, [FromBody] ItemAtualizadoDTO item)
        {
            try
            {
                var _item = await _appDbContext.ItensMenu.FindAsync(id);
                if (_item == null) return NotFound();

                _item.Nome = string.IsNullOrWhiteSpace(item.Nome) ? _item.Nome : item.Nome;
                _item.Descricao = string.IsNullOrWhiteSpace(item.Descricao) ? _item.Descricao : item.Descricao;
                if(item.Preco.HasValue) _item.Preco = item.Preco.Value;


                await _appDbContext.SaveChangesAsync();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeletarItemMenu(int id)
        {
            var _item = await _appDbContext.ItensMenu.FindAsync(id);
            if (_item == null) return NotFound();
            _item.Ativo = false;

            await _appDbContext.SaveChangesAsync();
            return Ok();
        }


    }
}
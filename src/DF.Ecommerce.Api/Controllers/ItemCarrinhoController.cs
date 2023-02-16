using DF.Ecommerce.Domain.Interfaces.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DF.Ecommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemCarrinhoController : ControllerBase
    {
        private readonly IItemCarrinhoRepository _itemCarrinhoRepository;

        public ItemCarrinhoController(IItemCarrinhoRepository itemCarrinhoRepository)
        {
            _itemCarrinhoRepository = itemCarrinhoRepository;
        }

        [HttpPut]
        public async Task<IActionResult> AtualizarQuantidade(Guid idProduto, Guid idCarrinho, int quantidade)
        {
            var quantidadeAtualizada = await _itemCarrinhoRepository.AtualizarQuantidade(idProduto,idCarrinho, quantidade);
            return Ok(quantidadeAtualizada);
        }

        [HttpDelete]
        public async Task<IActionResult> LimparCarrinho(Guid idCarrinho)
        {
            await _itemCarrinhoRepository.LimparCarrinho(idCarrinho);
            return Ok();
        }

        [HttpDelete("/itemcarrinho/{idProduto}/{idCarrinho}")]
        public async Task<IActionResult> RemoverItemCarrinho([FromRoute]Guid idProduto, [FromRoute] Guid idCarrinho)
        {

            if(string.IsNullOrEmpty(idCarrinho.ToString()) || string.IsNullOrEmpty(idProduto.ToString()))
            {
                return BadRequest("Um dos Paramertros está vazio");
            }

            await _itemCarrinhoRepository.RemoverItemCarrinho(idProduto,idCarrinho);
            return Ok();
        }
    }
}

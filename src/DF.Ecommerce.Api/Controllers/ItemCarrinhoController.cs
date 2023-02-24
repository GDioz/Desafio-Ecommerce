using DF.Ecommerce.Application.Models;
using DF.Ecommerce.Application.Results;
using DF.Ecommerce.Domain.Interfaces.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace DF.Ecommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemCarrinhoController : ApiBaseController
    {
        private readonly IItemCarrinhoAplication _itemCarrinhoAplication;

        public ItemCarrinhoController(IItemCarrinhoAplication itemCarrinhoAplication)
        {
            _itemCarrinhoAplication = itemCarrinhoAplication;
        }

        /// <summary>
        /// Atualizar Quantidade 
        /// </summary>
        /// <returns>
        /// Retorna a Quantidade Atualizada
        /// </returns>
        [HttpPut]
        [ProducesResponseType(typeof(ItemCarrinhoModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AtualizarQuantidade(Guid idProduto, Guid idCarrinho, int quantidade)
        {
            var result =  await _itemCarrinhoAplication.AtualizarQuantidade(idProduto,idCarrinho, quantidade);

            if (result > 0)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        /// <summary>
        /// Limpar Carrinho
        /// </summary>
        /// <returns>
        /// Confirmação da limpeza do Carrinho
        /// </returns>
        [HttpDelete]
        [ProducesResponseType(typeof(ItemCarrinhoModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> LimparCarrinho(Guid idCarrinho)
        {
            var result = await _itemCarrinhoAplication.LimparCarrinho(idCarrinho);
            if (result > 0)
            {
                return Ok(result);
            }

            return BadRequest();

        }

        /// <summary>
        /// Remover Item do Carrinho
        /// </summary>
        /// <returns>
        /// Retorna o Item Excluido
        /// </returns>
        [HttpDelete("/itemcarrinho/{idProduto}/{idCarrinho}")]
        [ProducesResponseType(typeof(ItemCarrinhoModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RemoverItemCarrinho([FromRoute]Guid idProduto, [FromRoute] Guid idCarrinho)
        {

            if(string.IsNullOrEmpty(idCarrinho.ToString()) || string.IsNullOrEmpty(idProduto.ToString()))
            {
                return BadRequest("Um dos Paramertros está vazio");
            }

            var result = await _itemCarrinhoAplication.RemoverItemCarrinho(idProduto, idCarrinho);
            if (result > 0)
            {
                return Ok(result);
            }

            return BadRequest();
        }
    }
}

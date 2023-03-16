using DF.Ecommerce.Application;
using DF.Ecommerce.Application.Interfaces;
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
    [Route("api/v{version:apiVersion}/[controller]")]
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
        public async Task<IActionResult> AtualizarQuantidade(Guid idProduto, string cpf, int quantidade)
        {
            var result = await _itemCarrinhoAplication.AtualizarQuantidade(idProduto, cpf, quantidade);

            if (result.Invalid)
            {
                var logMessage = MensagemErro(result.Notifications);

                Log.Error(logMessage);

                if (result.StatusCode == StatusCodes.Status404NotFound)
                    return NotFound(new ErrorModel(result.Notifications));

                return BadRequest(new ErrorModel(result.Notifications));
            }

            return Ok(result.Object);
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
        public async Task<IActionResult> LimparCarrinho(string cpf)
        {
            var result = await _itemCarrinhoAplication.LimparCarrinho(cpf);

            if (result.Invalid)
            {
                var logMessage = MensagemErro(result.Notifications);

                Log.Error(logMessage);

                if (result.StatusCode == StatusCodes.Status404NotFound)
                    return NotFound(new ErrorModel(result.Notifications));

                return BadRequest(new ErrorModel(result.Notifications));
            }

            return Ok(new MsgModel(result.Object));

        }

        /// <summary>
        /// Remover Item do Carrinho
        /// </summary>
        /// <returns>
        /// Retorna o Item Excluido
        /// </returns>
        [HttpDelete("{idProduto}/{cpf}")]
        [ProducesResponseType(typeof(ItemCarrinhoModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RemoverItemCarrinho([FromRoute]Guid idProduto, [FromRoute] string cpf)
        {
            var result = await _itemCarrinhoAplication.RemoverItemCarrinho(idProduto, cpf);

            if (result.Invalid)
            {
                var logMessage = MensagemErro(result.Notifications);

                Log.Error(logMessage);

                if (result.StatusCode == StatusCodes.Status404NotFound)
                    return NotFound(new ErrorModel(result.Notifications));

                return BadRequest(new ErrorModel(result.Notifications));
            }

            return Ok(new MsgModel(result.Object));
        }
    }
}

using DF.Ecommerce.Application;
using DF.Ecommerce.Application.Interfaces;
using DF.Ecommerce.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Threading.Tasks;

namespace DF.Ecommerce.Api.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [Authorize]
    public class CarrinhoController : ApiBaseController
    {
        private readonly ICarrinhoAplication _carrinhoAplication;

        public CarrinhoController(ICarrinhoAplication carrinhoAplication)
        {
            _carrinhoAplication = carrinhoAplication;
        }

        /// <summary>
        /// Obter Carrinho
        /// </summary>
        /// <returns>
        /// Retorna o Carrinho
        /// </returns>
        [HttpGet]
        [ProducesResponseType(typeof(CarrinhoModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObterCarrinho (string cpf)
        {
            var result = await _carrinhoAplication.ObterCarrinho(cpf);

            if (result.Invalid)
            {
                var logMessage = MensagemErro(result.Notifications);

                Log.Error(logMessage);

                return BadRequest(new ErrorModel(result.Notifications));
            }

            return Ok(result.Object);
        }

        [HttpPost("adicionar/item")]
        public async Task<IActionResult> AdicionarItemCarrinho(Guid codigoProduto, string cpf)
        {
            var result = await _carrinhoAplication.AdicionarItem(codigoProduto, cpf);

            if (result.Invalid)
            {
                var logMessage = MensagemErro(result.Notifications);

                Log.Error(logMessage);

                return BadRequest(new ErrorModel(result.Notifications));
            }

            return Ok(result.Object);
        }

        /// <summary>
        /// Adiciona um cupom de desconto ao carrinho
        /// </summary>
        /// <param name="idCupom">ID do Cupom</param>
        /// <param name="documento">Documento do cliente</param>
        /// <returns>Retorna o carrinho do cliente</returns>
        [HttpPost("adicionar-cupom")]
        [ProducesResponseType(typeof(CarrinhoModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AdicionarCupomDesconto(Guid idCupom, string documento)
        {
            var result = await _carrinhoAplication.AdicionarCupomDesconto(idCupom, documento);

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
    }
}

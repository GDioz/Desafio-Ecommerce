using DF.Ecommerce.Application.Interfaces;
using DF.Ecommerce.Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Threading.Tasks;

namespace DF.Ecommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
    }
}

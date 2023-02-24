using DF.Ecommerce.Application.Interfaces;
using DF.Ecommerce.Application.Models;
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

        [HttpGet]
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

using DF.Ecommerce.Domain.Interfaces.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DF.Ecommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrinhoController : ControllerBase
    {
        private readonly ICarrinhoRepository _carrinhoRepository;

        public CarrinhoController(ICarrinhoRepository carrinhoRepository)
        {
            _carrinhoRepository = carrinhoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> ObterCarrinho (string cpf)
        {
            var carrinho = await _carrinhoRepository.ObterCarrinho(cpf);
            return Ok(carrinho);
        }
    }
}

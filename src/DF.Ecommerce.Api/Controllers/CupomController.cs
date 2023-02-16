using DF.Ecommerce.Domain.Entites;
using DF.Ecommerce.Domain.Interfaces.Repository;
using DF.Ecommerce.Infrastructure.Context;
using DF.Ecommerce.Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DF.Ecommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CupomController : ControllerBase
    {
        private readonly ICupomRepository _cupomRepository;

        public CupomController(ICupomRepository cupomRepository)
        {
            _cupomRepository = cupomRepository;

        }

        [HttpPut]
        public async Task<IActionResult> AtualizarInformacoesDoCumpom(Cupom cupom)
        {
            var clientes = await _cupomRepository.AtualizarInformacoesDoCumpom(cupom);
            return Ok(clientes);
        }

        [HttpGet]
        public async Task<IActionResult> ObterClientes()
        {
            var cupons = await _cupomRepository.ObterTodos();
            return Ok(cupons);
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarCupom(Cupom cupom)
        {
            var addCupom = await _cupomRepository.Adicionar(cupom);
            return Ok(addCupom);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoverCupom([FromRoute] Guid id)
        {
            await _cupomRepository.Remover(id);
            return Ok();
        }
    }
}

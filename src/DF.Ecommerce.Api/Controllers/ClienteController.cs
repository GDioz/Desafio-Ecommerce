using DF.Ecommerce.Domain.Entites;
using DF.Ecommerce.Domain.Interfaces.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace DF.Ecommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;
        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
      
        }

        [HttpGet]
        public async Task<IActionResult> ObterClientes()
        {
            var clientes = await _clienteRepository.ObterTodos();
            return Ok(clientes);
        }

        [HttpPost] 
        public async Task<IActionResult> CadastrarCliente(Cliente cliente)
        {
            var addCliente = await _clienteRepository.Adicionar(cliente);
            return Ok(addCliente);
        }

        [HttpGet("documento/cpf")]
        public async Task<IActionResult> ObterClientesPorDocumento(string cpf)
        {
            var clientes = await _clienteRepository.ObterClientePorDocumento(cpf);
            return Ok(clientes);
        }

        [HttpPut]
        public async Task<IActionResult> AtualizarInformacoes(Cliente cliente)
        {
            var clienteAtualizado = await _clienteRepository.AtualizarInformacoes(cliente);
            return Ok(clienteAtualizado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoverCliente([FromRoute]Guid id)
        {
            await _clienteRepository.Remover(id);
            return Ok();
        }
    }
}

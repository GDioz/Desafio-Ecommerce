using DF.Ecommerce.Application.Models;
using DF.Ecommerce.Domain.Entites;
using DF.Ecommerce.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace DF.Ecommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ApiBaseController
    {
        private readonly IClienteAplication _clienteAplication;
        public ClienteController(IClienteAplication clienteAplication)
        {
            _clienteAplication = clienteAplication;
      
        }

        [HttpGet]
        public async Task<IActionResult> ObterClientes()
        {
            var result = await _clienteAplication.ObterClientes();

            if (result.Invalid)
            {
                var logMessage = MensagemErro(result.Notifications);

                Log.Error(logMessage);

                return BadRequest(new ErrorModel(result.Notifications));
            }

            return Ok(result.Object);
        }

        [HttpPost] 
        public async Task<IActionResult> CadastrarCliente(ClienteModel cliente)
        {
            var result = await _clienteAplication.InserirCliente(cliente);

            if (result.Invalid)
            {
                var logMessage = MensagemErro(result.Notifications);

                Log.Error(logMessage);

                return BadRequest(new ErrorModel(result.Notifications));
            }

            return Ok(result.Object);
        }

        [HttpGet("documento/cpf")]
        public async Task<IActionResult> ObterClientesPorDocumento(string cpf)
        {
            var result = await _clienteAplication.ObterClientePeloDocumento(cpf);

            if (result.Invalid)
            {
                var logMessage = MensagemErro(result.Notifications);

                Log.Error(logMessage);

                return BadRequest(new ErrorModel(result.Notifications));
            }

            return Ok(result.Object);
        }

        [HttpPut]
        public async Task<IActionResult> AtualizarInformacoes(ClienteModel cliente)
        {
            var result = await _clienteAplication.AtualizarInformacoes(cliente);

            if (result.Invalid)
            {
                var logMessage = MensagemErro(result.Notifications);

                Log.Error(logMessage);

                return BadRequest(new ErrorModel(result.Notifications));
            }

            return Ok(result.Object);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoverCliente([FromRoute]Guid id)
        {
            var result = await _clienteAplication.RemoverCliente(id);

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

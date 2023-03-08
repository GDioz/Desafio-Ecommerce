using DF.Ecommerce.Application.Models;
using DF.Ecommerce.Domain.Entites;
using DF.Ecommerce.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace DF.Ecommerce.Api.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [Authorize]
    public class ClienteController : ApiBaseController
    {
        private readonly IClienteAplication _clienteAplication;
        public ClienteController(IClienteAplication clienteAplication)
        {
            _clienteAplication = clienteAplication;
      
        }

        /// <summary>
        /// Obter Clientes
        /// </summary>
        /// <returns>
        /// Retorna uma lista de Clientes
        /// </returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<ClienteModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
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

        /// <summary>
        /// Cadastrar Cliente
        /// </summary>
        /// <returns>
        /// Retorna o Cliente Cadastrado
        /// </returns>
        [HttpPost]
        [ProducesResponseType(typeof(ClienteModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
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

        /// <summary>
        /// Obter Cliente por Documento
        /// </summary>
        /// <returns>
        /// Retorna o Cliente pelo cpf
        /// </returns>
        [HttpGet("documento/cpf")]
        [ProducesResponseType(typeof(ClienteModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
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

        /// <summary>
        /// Atualizar Cliente
        /// </summary>
        /// <returns>
        /// Retorna o Cliente Atualizado
        /// </returns>
        [HttpPut]
        [ProducesResponseType(typeof(ClienteModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
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

        /// <summary>
        /// Remover Cliente
        /// </summary>
        /// <returns>
        /// Retorna o Cliente Removido
        /// </returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ClienteModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
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

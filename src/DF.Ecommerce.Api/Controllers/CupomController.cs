using DF.Ecommerce.Application.Models;
using DF.Ecommerce.Application.Interfaces;
using DF.Ecommerce.Domain.Entites;
using DF.Ecommerce.Infrastructure.Context;
using DF.Ecommerce.Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace DF.Ecommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CupomController : ApiBaseController
    {
        private readonly ICupomAplication _cupomAplication;

        public CupomController(ICupomAplication cupomAplication)
        {
            _cupomAplication = cupomAplication;

        }

        /// <summary>
        /// Atualizar Informações do Produto
        /// </summary>
        /// <returns>Atualiza as Informações do Produto</returns>
        [HttpPut]
        [ProducesResponseType(typeof(CupomModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AtualizarInformacoesDoCumpom(CupomModel cupom)
        {
            var result = await _cupomAplication.AtualizarInformacoes(cupom);

            if (result.Invalid)
            {
                var logMessage = MensagemErro(result.Notifications);

                Log.Error(logMessage);

                return BadRequest(new ErrorModel(result.Notifications));
            }

            return Ok(result.Object);

        }

        /// <summary>
        /// Obter Cupons
        /// </summary>
        /// <returns>
        /// Retorna uma lista de Cupons
        /// </returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<CupomModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ObterCupons()
        {
            var result = await _cupomAplication.ObterCupons();

            if (result.Invalid)
            {
                var logMessage = MensagemErro(result.Notifications);

                Log.Error(logMessage);

                return BadRequest(new ErrorModel(result.Notifications));
            }

            return Ok(result.Object);
        }

        /// <summary>
        /// Cadastrar Cupom
        /// </summary>
        /// <returns>
        /// Cadastra o Cupom no Banco de Dados
        /// </returns>
        [HttpPost]
        [ProducesResponseType(typeof(CupomModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CadastrarCupom(CupomModel cupom)
        {
            var result = await _cupomAplication.InserirCupom(cupom);

            if (result.Invalid)
            {
                var logMessage = MensagemErro(result.Notifications);

                Log.Error(logMessage);

                return BadRequest(new ErrorModel(result.Notifications));
            }

            return Ok(result.Object);

        }

        /// <summary>
        /// Remover Cupom
        /// </summary>
        /// <returns>
        /// Cadastra o Cupom no Banco de Dados
        /// </returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(CupomModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> RemoverCupom([FromRoute] Guid id)
        {
            var result = await _cupomAplication.RemoverCupom(id);

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

using DF.Ecommerce.Application;
using DF.Ecommerce.Application.Interfaces;
using DF.Ecommerce.Application.Models;
using DF.Ecommerce.Domain.Entites;
using DF.Ecommerce.Domain.Interfaces.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Serilog;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DF.Ecommerce.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ApiBaseController
    {
        private readonly IProdutoAplication _produtoAplication;

        public ProdutoController(IProdutoAplication produtoAplication)
        {
            _produtoAplication = produtoAplication;
        }

        /// <summary>
        /// Obter Produtos
        /// </summary>
        /// <returns>
        /// Retorna uma lista de Produtos
        /// </returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<CupomModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ObterProdutos()
        {
            var result = await _produtoAplication.ObterProdutos();
            if(result.Invalid)
            {
                var logMessage = MensagemErro(result.Notifications);

                Log.Error(logMessage);

                return BadRequest(new ErrorModel(result.Notifications));
            }

            return Ok(result.Object);
        }

        /// <summary>
        /// Obter produto pelo codigo
        /// </summary>
        /// <param name="codigo">Código do produto</param>
        /// <returns>Consulta informações de um produto</returns>
        [HttpGet("{codigo}")]
        [ProducesResponseType(typeof(CupomModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObterProdutoPorId(Guid codigo)
        {
            var result = await _produtoAplication.ObterProdutoPeloId(codigo);

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
        /// Cadastrar Produto
        /// </summary>
        /// <returns>Cadastra o Produto no Banco de Dados</returns>
        [HttpPost]
        [ProducesResponseType(typeof(CupomModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CadastrarProduto(CupomModel produto)
        {
            var result = await _produtoAplication.InserirProduto(produto);

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
        /// Remover Produto
        /// </summary>
        /// /// <param name="id">Código do produto</param>
        /// <returns>Confirmação da Remoção do Produto</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(CupomModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]

        public async Task<IActionResult> RemoverProduto([FromRoute] Guid id)
        {
            var result = await _produtoAplication.RemoverProduto(id);

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
        /// Atualizar Informações do Produto
        /// </summary>
        /// <returns>Atualiza as Informações do Produto</returns>
        [HttpPut]
        [ProducesResponseType(typeof(CupomModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AtualizarInformacoesDoProduto(CupomModel produto)
        {
            var result = await _produtoAplication.AtualizarInformacoes(produto);

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

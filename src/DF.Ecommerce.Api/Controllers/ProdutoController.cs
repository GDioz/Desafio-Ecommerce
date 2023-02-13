using DF.Ecommerce.Domain.Entites;
using DF.Ecommerce.Domain.Interfaces.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DF.Ecommerce.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> ObterProdutos()
        {
            var produtos = await _produtoRepository.ObterTodos();
            return Ok(produtos);
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarProduto(Produto produto)
        {
            var addProduto = await _produtoRepository.Adicionar(produto);
            return Ok(produto);
        }

        [HttpDelete]
        public async Task<IActionResult> RemoverProduto(Guid id)
        {
            await _produtoRepository.Remover(id);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> AtualizarAtualizarInformacoesDoProduto(Produto produto)
        {
            var produtoAtualizado = await _produtoRepository.AtualizarInformacoesDoProduto(produto);
            return Ok(produtoAtualizado);
        }
    }
}

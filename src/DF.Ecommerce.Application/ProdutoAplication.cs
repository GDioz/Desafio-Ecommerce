using AutoMapper;
using DF.Ecommerce.Application.Interfaces;
using DF.Ecommerce.Application.Models;
using DF.Ecommerce.Application.Results;
using DF.Ecommerce.Domain.Entites;
using DF.Ecommerce.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DF.Ecommerce.Application
{
    public class ProdutoAplication : IProdutoAplication
    {
        private readonly IMapper _mapper;
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoAplication(IMapper mapper, IProdutoRepository produtoRepository)
        {
            _mapper = mapper;
            _produtoRepository = produtoRepository;
        }

        public async Task<Result<ProdutoModel>> ObterProdutoPeloId(Guid id)
        {
            var produto = await _produtoRepository.ObterPorId(id);
            return Result<ProdutoModel>.Ok(_mapper.Map<ProdutoModel>(produto));
        }

        public async Task<Result<List<ProdutoModel>>> ObterProdutos()
        {
            var produtos = await _produtoRepository.ObterTodos();
            return Result<List<ProdutoModel>>.Ok(_mapper.Map<List<ProdutoModel>>(produtos));
        }

        public async Task<Result<ProdutoModel>> AtualizarInformacoes(ProdutoModel produtoModel)
        {
            var atualizado = _mapper.Map<Produto>(produtoModel);
            var produtoAtualizado = await _produtoRepository.Atualizar(atualizado);
            return Result<ProdutoModel>.Ok(_mapper.Map<ProdutoModel>(produtoAtualizado));
        }

        public async Task<Result<ProdutoModel>> InserirProduto(ProdutoModel produtoModel)
        {
            var addProduto = _mapper.Map<Produto>(produtoModel);
            var clienteAdicionado = await _produtoRepository.Adicionar(addProduto);
            return Result<ProdutoModel>.Ok(_mapper.Map<ProdutoModel>(clienteAdicionado));
        }

        public async Task<Result<string>> RemoverProduto(Guid id)
        {
            await _produtoRepository.Remover(id);
            return Result<String>.Ok("Produto Removido com Sucesso!");
        }
    }
}

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

        public async Task<Result<CupomModel>> ObterProdutoPeloId(Guid id)
        {
            var produto = await _produtoRepository.ObterPorId(id);
            return Result<CupomModel>.Ok(_mapper.Map<CupomModel>(produto));
        }

        public async Task<Result<List<CupomModel>>> ObterProdutos()
        {
            var produtos = await _produtoRepository.ObterTodos();
            return Result<List<CupomModel>>.Ok(_mapper.Map<List<CupomModel>>(produtos));
        }

        public async Task<Result<CupomModel>> AtualizarInformacoes(CupomModel produtoModel)
        {
            var atualizado = _mapper.Map<Produto>(produtoModel);
            var produtoAtualizado = await _produtoRepository.Atualizar(atualizado);
            return Result<CupomModel>.Ok(_mapper.Map<CupomModel>(produtoAtualizado));
        }

        public async Task<Result<CupomModel>> InserirProduto(CupomModel produtoModel)
        {
            var addProduto = _mapper.Map<Produto>(produtoModel);
            var clienteAdicionado = await _produtoRepository.Adicionar(addProduto);
            return Result<CupomModel>.Ok(_mapper.Map<CupomModel>(clienteAdicionado));
        }

        public async Task<Result<string>> RemoverProduto(Guid id)
        {
            await _produtoRepository.Remover(id);
            return Result<String>.Ok("Produto Removido com Sucesso!");
        }
    }
}

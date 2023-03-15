using AutoMapper;
using DF.Ecommerce.Application.Interfaces;
using DF.Ecommerce.Application.Models;
using DF.Ecommerce.Application.Results;
using DF.Ecommerce.Domain.Entites;
using DF.Ecommerce.Domain.Interfaces.Repository;
using DF.Ecommerce.Domain.Interfaces.UnitOfWork;
using DF.Ecommerce.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DF.Ecommerce.Application
{
    public class ItemCarrinhoAplication : IItemCarrinhoAplication
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWorkCarrinho _unitOfWorkCarrinho;

        public ItemCarrinhoAplication(IMapper mapper,IUnitOfWorkCarrinho unitOfWorkCarrinho)
        {
            _mapper = mapper;
            _unitOfWorkCarrinho = unitOfWorkCarrinho;
        }

        #region Atualizar Quantidade
        public async Task<Result<CarrinhoModel>> AtualizarQuantidade(Guid idProduto, string cpf, int quantidade)
        {
            if (!CpfCnpjUtils.IsCpf(cpf))
                return Result<CarrinhoModel>.Error("O documento informado não é um CPF válido.", (int)HttpStatusCode.BadRequest);

            var cliente = await _unitOfWorkCarrinho.ClienteRepository.ObterClientePorDocumento(cpf);

            if (cliente != null)
            {
                var result = await _unitOfWorkCarrinho.ItemCarrinhoRepository.AtualizarQuantidade(idProduto, cliente.Carrinho.Id, quantidade);
                
                RecalcularValorTotal(cliente);
                if (result > 0)
                    return Result<CarrinhoModel>.Ok(_mapper.Map<CarrinhoModel>(cliente.Carrinho));
            }

            return Result<CarrinhoModel>.Error("Cliente não foi encontrado.", (int)HttpStatusCode.NotFound);
        }
        #endregion


        #region Limpar Carrinho
        public async Task<Result<string>> LimparCarrinho(string cpf)
        {
            if (!CpfCnpjUtils.IsCpf(cpf))
                return Result<string>.Error("O documento informado não é um CPF válido.", (int)HttpStatusCode.BadRequest);

            var cliente = await _unitOfWorkCarrinho.ClienteRepository.ObterClientePorDocumento(cpf);

            if (cliente != null)
            {
                var result = await _unitOfWorkCarrinho.ItemCarrinhoRepository.LimparCarrinho(cliente.Carrinho.Id);

                RecalcularValorTotal(cliente);
                if (result > 0)
                    return Result<string>.Ok("Carrinho foi limpo.");
            }

            return Result<string>.Error("Cliente não foi encontrado.", (int)HttpStatusCode.NotFound);
        }
        #endregion

        #region Remover Item
        public async Task<Result<string>> RemoverItemCarrinho(Guid idProduto, string cpf)
        {
            if (!CpfCnpjUtils.IsCpf(cpf))
                return Result<string>.Error("O documento informado não é um CPF válido.", (int)HttpStatusCode.BadRequest);

            var cliente = await _unitOfWorkCarrinho.ClienteRepository.ObterClientePorDocumento(cpf);

            if (cliente != null)
            {
                var result = await _unitOfWorkCarrinho.ItemCarrinhoRepository.RemoverItemCarrinho(idProduto, cliente.Carrinho.Id);

                RecalcularValorTotal(cliente);
                if (result > 0)
                    return Result<string>.Ok("Item removido do carrinho.");
            }

            return Result<string>.Error("Cliente não foi encontrado.", (int)HttpStatusCode.NotFound);
        }

        #endregion

        #region RecalcularValorTotal
        private int RecalcularValorTotal(Cliente cliente)
        {
            if (cliente.Carrinho.Cupom != null)
                cliente.Carrinho.VlTotal = (cliente.Carrinho.ItemCarrinhos.Sum(x => x.Produto.Preco * x.Quantidade)) - cliente.Carrinho.Cupom.VlCupom;
            else
                cliente.Carrinho.VlTotal = (cliente.Carrinho.ItemCarrinhos.Sum(x => x.Produto.Preco * x.Quantidade));

            return _unitOfWorkCarrinho.Save();
        }
        #endregion
    }
}

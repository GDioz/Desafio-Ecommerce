using AutoMapper;
using DF.Ecommerce.Application.Interfaces;
using DF.Ecommerce.Application.Models;
using DF.Ecommerce.Application.Results;
using DF.Ecommerce.Domain.Entites;
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
    public class CarrinhoAplication : ICarrinhoAplication
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWorkCarrinho _unitOfWorkCarrinho;


        public CarrinhoAplication(IMapper mapper, IUnitOfWorkCarrinho unitOfWorkCarrinho)
        {
            _mapper = mapper;
            _unitOfWorkCarrinho =  unitOfWorkCarrinho;
        }

        #region ObterCarrinho
        public async Task<Result<CarrinhoModel>> ObterCarrinho(string documento)
        {
            if (!CpfCnpjUtils.IsCpf(documento))
                return Result<CarrinhoModel>.Error("Documento Informado não é um CPF válido!",(int)HttpStatusCode.BadRequest);
            
            var carrinho = await _unitOfWorkCarrinho.CarrinhoRepository.ObterCarrinho(documento);

            if (carrinho != null)
                return Result<CarrinhoModel>.Ok(_mapper.Map<CarrinhoModel>(carrinho));
            else
                return Result<CarrinhoModel>.Error("Nenhum Carrinho foi encontrado para este cliente!",(int)HttpStatusCode.NotFound);


        }
        #endregion

        #region AdicionarCupomDesconto
        public async Task<Result<CarrinhoModel>> AdicionarCupomDesconto(Guid idCupom, string documento)
        {
            if (!CpfCnpjUtils.IsCpf(documento))
                return Result<CarrinhoModel>.Error("Documento Informado não é um CPF válido!", (int)HttpStatusCode.BadRequest);

            var cliente = await _unitOfWorkCarrinho.ClienteRepository.ObterClientePorDocumento(documento);
            if(cliente != null)
            {
                var cupom = await _unitOfWorkCarrinho.CupomRepository.ObterPorId(idCupom);
                cliente.Carrinho.IdCupom = idCupom;
                cliente.Carrinho.Cupom = cupom;
                var result = RecalcularValorTotal(cliente);
                if (result > 0)
                    return Result<CarrinhoModel>.Ok(_mapper.Map<CarrinhoModel>(cliente.Carrinho));
                else
                    return Result<CarrinhoModel>.Error("Cupom já adicionado!",(int) HttpStatusCode.BadRequest);
            }
            return Result<CarrinhoModel>.Error("Cliente não foi encontrado!", (int)HttpStatusCode.NotFound);
        }
        #endregion

        #region AdicionarItem
        public async Task<Result<CarrinhoModel>> AdicionarItem(Guid idProduto, string documento)
        {
            if (!CpfCnpjUtils.IsCpf(documento))
                return Result<CarrinhoModel>.Error("Documento Informado não é um CPF válido!", (int)HttpStatusCode.BadRequest);

            var cliente = await _unitOfWorkCarrinho.ClienteRepository.ObterClientePorDocumento(documento);
            if(cliente != null)
            {
                var itensDic = cliente.Carrinho.ItemCarrinhos.ToDictionary( x => x.IdProduto);
                if(itensDic.ContainsKey(idProduto))
                {
                    var item = itensDic[idProduto];
                    item.Quantidade++;
                }
                else
                {
                    var produto = await _unitOfWorkCarrinho.ProdutoRepository.ObterPorId(idProduto);
                    var itemCarrinho = new ItemCarrinho()
                    {
                        IdCarrinho = cliente.Carrinho.Id,
                        IdProduto = idProduto,
                        Quantidade = 1,
                        Produto = produto
                    };
                    cliente.Carrinho.ItemCarrinhos.Add(itemCarrinho);
                }
                int result = RecalcularValorTotal(cliente);

                if (result > 0)
                    return Result<CarrinhoModel>.Ok(_mapper.Map<CarrinhoModel>(cliente.Carrinho));
      
            }
            return Result<CarrinhoModel>.Error("Cliente não foi encontrado!",(int) HttpStatusCode.NotFound);
        }
        #endregion

        #region AtualizarQuantidade
        public async Task<Result<CarrinhoModel>> AtualizarQuantidade(Guid idProduto, string documento, int quantidade)
        {
            if (!CpfCnpjUtils.IsCpf(documento))
                return Result<CarrinhoModel>.Error("Documento Informado não é um CPF válido!", (int)HttpStatusCode.BadRequest);

            var cliente = await _unitOfWorkCarrinho.ClienteRepository.ObterClientePorDocumento(documento);
            if(cliente != null)
            {
                var result = await _unitOfWorkCarrinho.ItemCarrinhoRepository.AtualizarQuantidade(idProduto, cliente.Carrinho.Id, quantidade);
                RecalcularValorTotal(cliente);
                if (result > 0)
                    return Result<CarrinhoModel>.Ok(_mapper.Map<CarrinhoModel>(cliente.Carrinho));
            }

            return Result<CarrinhoModel>.Error("Cliente não foi encontrado!", (int)HttpStatusCode.NotFound);
        }
        #endregion

        #region LimparCarrinho
        public async Task<Result<string>> LimparCarrinho(string documento)
        {
            if (!CpfCnpjUtils.IsCpf(documento))
                return Result<string>.Error("Documento Informado não é um CPF válido!", (int)HttpStatusCode.BadRequest);

            var cliente = await _unitOfWorkCarrinho.ClienteRepository.ObterClientePorDocumento(documento);
            if(cliente != null)
            {
                var result = await _unitOfWorkCarrinho.ItemCarrinhoRepository.LimparCarrinho(cliente.Carrinho.Id);
                RecalcularValorTotal(cliente);
                if (result > 0)
                    return Result<string>.Ok("Carrinho foi limpo!");
            }
            return Result<string>.Error("Cliente não foi encontrado!", (int)HttpStatusCode.NotFound);

        }
        #endregion

        #region RemoverItem
        public async Task<Result<string>> RemoverItem(Guid idProduto, string documento)
        {
            if (!CpfCnpjUtils.IsCpf(documento))
                return Result<string>.Error("Documento Informado não é um CPF válido!", (int)HttpStatusCode.BadRequest);

            var cliente = await _unitOfWorkCarrinho.ClienteRepository.ObterClientePorDocumento(documento);
            if(cliente != null)
            {
               var result = await _unitOfWorkCarrinho.ItemCarrinhoRepository.RemoverItemCarrinho(idProduto, cliente.Carrinho.Id);
                RecalcularValorTotal(cliente);
                if (result > 0)
                    return Result<string>.Ok("Item Removido do Carrinho com sucesso!");
            }
            return Result<string>.Error("Cliente não foi encontrado!", (int)HttpStatusCode.NotFound);
        }
        #endregion

        #region RecalcularValorTotal
        private int RecalcularValorTotal(Cliente cliente)
        {
            if(cliente.Carrinho.Cupom != null)
                cliente.Carrinho.VlTotal = (cliente.Carrinho.ItemCarrinhos.Sum(x => x.Produto.Preco * x.Quantidade)) - cliente.Carrinho.Cupom.VlCupom;
            else
                cliente.Carrinho.VlTotal = (cliente.Carrinho.ItemCarrinhos.Sum(x => x.Produto.Preco * x.Quantidade));

            return _unitOfWorkCarrinho.Save();
        }
        #endregion


    }
}

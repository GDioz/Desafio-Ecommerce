using AutoMapper;
using DF.Ecommerce.Application.Interfaces;
using DF.Ecommerce.Application.Models;
using DF.Ecommerce.Application.Results;
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

        public Task<Result<CarrinhoModel>> AdicionarCupomDesconto(Guid idCupom, string documento)
        {
            throw new NotImplementedException();
        }

        public Task<Result<CarrinhoModel>> AdicionarItem(Guid idProduto, string documento)
        {
            throw new NotImplementedException();
        }

        public Task<Result<CarrinhoModel>> AtualizarQuantidade(Guid idProduto, string documento, int quantidade)
        {
            throw new NotImplementedException();
        }

        public Task<Result<string>> LimparCarrinho(string documento)
        {
            throw new NotImplementedException();
        }



        public Task<Result<string>> RemoverItem(Guid idProduto, string documento)
        {
            throw new NotImplementedException();
        }
    }
}

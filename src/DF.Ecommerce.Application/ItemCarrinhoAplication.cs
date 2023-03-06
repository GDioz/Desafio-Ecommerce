using AutoMapper;
using DF.Ecommerce.Application.Interfaces;
using DF.Ecommerce.Application.Results;
using DF.Ecommerce.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DF.Ecommerce.Application
{
    public class ItemCarrinhoAplication : Interfaces.IItemCarrinhoAplication
    {
        private readonly IMapper _mapper;
        private readonly Domain.Interfaces.Repository.IItemCarrinhoRepository _itemCarrinhoRepository;

        public ItemCarrinhoAplication(IMapper mapper, Domain.Interfaces.Repository.IItemCarrinhoRepository itemCarrinhoRepository)
        {
            _mapper = mapper;
            _itemCarrinhoRepository = itemCarrinhoRepository;
        }

        public Task<Result<string>> AtualizarQuantidade(Guid idProduto, Guid idCarrinho, int quantidade)
        {
            throw new NotImplementedException();
        }

        public Task<Result<string>> LimparCarrinho(Guid idCarrinho)
        {
            throw new NotImplementedException();
        }

        public Task<Result<string>> RemoverItemCarrinho(Guid idProduto, Guid idCarrinho)
        {
            throw new NotImplementedException();
        }
    }
}
